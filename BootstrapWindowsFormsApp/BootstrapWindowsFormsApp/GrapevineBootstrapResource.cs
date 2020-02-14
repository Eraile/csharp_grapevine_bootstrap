using Grapevine.Interfaces.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BootstrapWindowsFormsApp
{
    [RestResource]
    public class GrapevineBootstrapResource
    {
        [RestRoute]
        public IHttpContext GetFile(IHttpContext context)
        {
            // Request URL received
            string requestURL = context.Request.Url.ToString();

            // Ex. If context.Request.Url is "http://localhost:1234/[...]", 
            // > search for ":1234/" 
            // > keep the [...] after it
            string stringToSearch = (":" + MainForm.PortNumber.ToString() + "/");
            if (requestURL.IndexOf(MainForm.PortNumber.ToString()) >= 0)
            {
                string requestedPath = requestURL.Substring(requestURL.IndexOf(stringToSearch) + stringToSearch.Length);

                // If found request is empty, default to index.html
                if (string.IsNullOrWhiteSpace(requestedPath) == true)
                    requestedPath = "index.html";

                // Local file path
                string localFilepath = MainForm.BaseFilesLocation + requestedPath;

                // If exist, distribute
                if (File.Exists(localFilepath) == true)
                {
                    try
                    {
                        // If index, dynamic values
                        if (requestedPath.Equals("index.html") == true)
                        {
                            // Get all lines
                            List<string> lines = new List<string>(File.ReadAllLines(localFilepath));
                            if (lines != null && lines.Count > 0)
                            {
                                // String builder
                                StringBuilder sb = new StringBuilder();

                                // Sample Data
                                GrapevineBootstrapSampleData bootstrapSampleData = new GrapevineBootstrapSampleData();

                                // Go through each lines
                                for (int i = 0; i < lines.Count; i++)
                                {
                                    sb.AppendLine(bootstrapSampleData.ParseLine(lines[i]));
                                }

                                // Give that file content as an answer
                                context.Response.SendResponse(Encoding.UTF8.GetBytes(sb.ToString()));
                            }

                        }
                        // Else, default answer
                        else
                        {
                            // Give that file content as an answer
                            context.Response.SendResponse(File.ReadAllBytes(localFilepath));
                        }

                        // And status is OK
                        context.Response.StatusCode = Grapevine.Shared.HttpStatusCode.Ok;

                        // Return answer
                        return context;
                    }
                    catch (Exception ex)
                    {
                        // Exception, internal server error
                        Console.WriteLine("[Error] During reading of file: " + localFilepath + " - Exception: " + ex.ToString());
                        context.Response.StatusCode = Grapevine.Shared.HttpStatusCode.InternalServerError;
                    }
                }
                // Else, error
                else
                {
                    // Not found
                    Console.WriteLine("[Error] Distributing file: " + localFilepath + " - File not found");
                    context.Response.StatusCode = Grapevine.Shared.HttpStatusCode.NotFound;
                }
            }
            // Return error
            else
            {
                // Error, internal server error
                Console.WriteLine("[Error] Port " + MainForm.PortNumber.ToString() + " not found in context URL");
                context.Response.StatusCode = Grapevine.Shared.HttpStatusCode.InternalServerError;
            }

            switch (context.Response.StatusCode)
            {
                case Grapevine.Shared.HttpStatusCode.NotFound:
                    // Notfound file path
                    string notFoundFilepath = MainForm.BaseFilesLocation + "400.html";
                    // Give that file content as an answer
                    context.Response.SendResponse(File.ReadAllBytes(notFoundFilepath));
                    break;

                case Grapevine.Shared.HttpStatusCode.InternalServerError:
                    // Notfound file path
                    string internalServerFilepath = MainForm.BaseFilesLocation + "500.html";
                    // Give that file content as an answer
                    context.Response.SendResponse(File.ReadAllBytes(internalServerFilepath));
                    break;
            }

            return context;
        }
    }
}
