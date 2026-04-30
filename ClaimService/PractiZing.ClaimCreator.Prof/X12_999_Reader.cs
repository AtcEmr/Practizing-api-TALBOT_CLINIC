
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Framework.Readers;
using EdiFabric.Framework.Writers;
using EdiFabric.Templates.Hipaa5010;
using PractiZing.Base.Entities.MasterService;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;

namespace PractiZing.ClaimCreator.Prof
{

    public class X12_999_Reader
    {

        public X12_999_Reader()
        {
            
        }

        public IEnumerable<object> Read(FileInfo file, string sourceFileFolder)
        {
            try
            {

                IEnumerable<object> rawObjects;                
                var x12Stream = File.ReadAllText(Path.Combine(sourceFileFolder, file.Name));                
                using (var stream = new MemoryStream())
                {
                    StreamWriter streamWriter = new StreamWriter(stream);
                    //write read text x12Stream in to stream
                    streamWriter.Write(x12Stream);
                    streamWriter.Flush();
                    stream.Position = 0;
                    // convert text x12Stream file to raw object
                    using (var ediReader = new X12Reader(stream, "EdiFabric.Templates.Hipaa"))
                    {
                        rawObjects = ediReader.ReadToEnd().ToList();
                    }
                    //flush the reader
                    stream.Flush();
                    rawObjects = rawObjects == null ? new List<object>() : rawObjects;
                }
                return rawObjects;

            }
            catch
            {
                throw;
            }

        }

        public IEnumerable<object> ReadWithOutEnevolop(FileInfo file, string sourceFileFolder)
        {
            try
            {

                IEnumerable<object> rawObjects;
                var settings = new X12ReaderSettings() { NoEnvelope = true };
                var x12Stream = File.ReadAllText(Path.Combine(sourceFileFolder, file.Name));
                using (var stream = new MemoryStream())
                {
                    StreamWriter streamWriter = new StreamWriter(stream);
                    //write read text x12Stream in to stream
                    streamWriter.Write(x12Stream);
                    streamWriter.Flush();
                    stream.Position = 0;
                    // convert text x12Stream file to raw object
                    using (var ediReader = new X12Reader(stream, "EdiFabric.Templates.Hipaa", settings))
                    {
                        rawObjects = ediReader.ReadToEnd().ToList();
                    }
                    //flush the reader
                    stream.Flush();
                    rawObjects = rawObjects == null ? new List<object>() : rawObjects;
                }
                return rawObjects;

            }
            catch
            {
                throw;
            }

        }


    }
}
