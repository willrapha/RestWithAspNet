﻿using System.IO;

namespace RestWithAspNetFiles.Business.Implementations
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fullPath = path + "\\Other\\aspnet-life-cycles-events.pdf";

            return File.ReadAllBytes(fullPath);
        }
    }
}