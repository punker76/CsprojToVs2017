using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project2015To2017.Definition;
using Project2015To2017.Writing;

namespace Project2015To2017Tests
{
	[TestClass]
    public class ProjectWriterTest
	{
		[TestMethod]
		public void GenerateAssemblyInfoOnNothingSpecifiedTest()
		{
			var writer = new ProjectWriter();
			var xmlNode = writer.CreateXml(new Project
			{
				AssemblyAttributes = new AssemblyAttributes(),
				FilePath = new System.IO.FileInfo("test.cs")
			});

			var generateAssemblyInfo = xmlNode.Element("PropertyGroup").Element("GenerateAssemblyInfo");
			Assert.IsNotNull(generateAssemblyInfo);
			Assert.AreEqual("false", generateAssemblyInfo.Value);
		}

		[TestMethod]
		public void GeneratesAssemblyInfoNodesWhenSpecifiedTest()
		{
			var writer = new ProjectWriter();
			var xmlNode = writer.CreateXml(new Project
			{
				AssemblyAttributes = new AssemblyAttributes {Company = "Company"},
				FilePath = new System.IO.FileInfo("test.cs")
			});

			var generateAssemblyInfo = xmlNode.Element("PropertyGroup").Element("GenerateAssemblyInfo");
			Assert.IsNull(generateAssemblyInfo);

			var generateAssemblyCompany = xmlNode.Element("PropertyGroup").Element("GenerateAssemblyCompanyAttribute");
			Assert.IsNotNull(generateAssemblyCompany);
			Assert.AreEqual("false", generateAssemblyCompany.Value);
		}

		[TestMethod]
		public void SkipDelaySignNull()
		{
			var writer = new ProjectWriter();
			var xmlNode = writer.CreateXml(new Project
			{
				DelaySign = null,
				FilePath = new System.IO.FileInfo("test.cs")
			});

			var delaySign = xmlNode.Element("PropertyGroup").Element("DelaySign");
			Assert.IsNull(delaySign);
		}

		[TestMethod]
		public void OutputDelaySignTrue()
		{
			var writer = new ProjectWriter();
			var xmlNode = writer.CreateXml(new Project
			{
				DelaySign = true,
				FilePath = new System.IO.FileInfo("test.cs")
			});

			var delaySign = xmlNode.Element("PropertyGroup").Element("DelaySign");
			Assert.IsNotNull(delaySign);
			Assert.AreEqual("true", delaySign.Value);
		}

		[TestMethod]
		public void OutputDelaySignFalse()
		{
			var writer = new ProjectWriter();
			var xmlNode = writer.CreateXml(new Project
			{
				DelaySign = false,
				FilePath = new System.IO.FileInfo("test.cs")
			});

			var delaySign = xmlNode.Element("PropertyGroup").Element("DelaySign");
			Assert.IsNotNull(delaySign);
			Assert.AreEqual("false", delaySign.Value);
		}
	}
}
