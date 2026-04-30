using AutoMapper;
using Microsoft.Extensions.Configuration;
using PractiZing.Base.Object.ReportService;
using PractiZing.Base.Service.PatientService;
using PractiZing.BusinessLogic.ReportService.Factories;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.ReportService.DTO;
using PractiZing.DataAccess.ReportService.DTO.Statement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace PractiZing.BusinessLogic.ReportService.Services
{
	public sealed class StatementFileService : IStatementFileService
	{
		private readonly Lazy<XmlSerializationService<StatementDTO>> _xml;
		private readonly IStatementDTOFactory _statementDTOFactory;
		private readonly string _statementXMLFolder;

		public StatementFileService(IStatementDTOFactory statementDTOFactory, IConfiguration configuration)
		{
			_xml = new Lazy<XmlSerializationService<StatementDTO>>();
			_statementDTOFactory = statementDTOFactory;
			_statementXMLFolder = configuration["StatementXMLFolder"];
		}

		public string GetXmlFile(IPatientChargeStatementDTO patientChargeStatementDTO, string fileName)
		{
			var dtoStatement = _statementDTOFactory.InitStatementDto(patientChargeStatementDTO);
			var file = _xml.Value.Serialize(dtoStatement);

			//// report xml saving path
			//string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this._statementXMLFolder);
			//if (!Directory.Exists(path))
			//{
			//	Directory.CreateDirectory(path);
			//}
			//string filePath = System.IO.Path.Combine(path, fileName);

			string filePath = fileName;
			using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
			{
				fs.Write(file, 0, file.Length);
			}

			return filePath;
		}

		public string CombineXmlFiles(List<IFileResultDTO> files, string saveFilePath)
		{
			var parentFile = files.First().Bytes;
			var newFile = new XDocument(new XElement("Statements", XDocument.Load(new MemoryStream(parentFile)).Root));
			//var element = newFile.Descendants("Statements").FirstOrDefault();
			//element.AddFirst(new XElement("NoOfCases", files.Count));		

			if (files.Count > 1)
			{
				foreach (var file in files.Skip(1))
				{
					var otherFile = XDocument.Load(new MemoryStream(file.Bytes));
					newFile.Root.Add(otherFile.Elements());
				}
			}
			using (var ms = new MemoryStream())
			{
				newFile.Save(ms);			
				File.WriteAllBytes(saveFilePath, ms.ToArray());				
			}

			return saveFilePath;
		}

		//public string GetStatementXMLFilePath(string fileName)
		//{
		//	string filePath = string.Empty;
		//	string statementXMLpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this._statementXMLFolder);
		//	DirectoryInfo info = new DirectoryInfo(statementXMLpath);
		//	FileInfo file = info.GetFiles().FirstOrDefault(i => i.Name.ToLower() == fileName.ToLower());
		//	if (file != null)
		//	{
		//		filePath = Path.Combine(statementXMLpath, file.Name);
		//	}
		//	return filePath;
		//}
	}
}
