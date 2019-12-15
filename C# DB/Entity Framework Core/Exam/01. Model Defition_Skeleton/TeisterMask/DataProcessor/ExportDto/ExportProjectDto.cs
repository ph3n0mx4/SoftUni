using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDto
    {
        //    <Project TasksCount = "10" >
        //< ProjectName > Hyster - Yale </ ProjectName >
        //< HasEndDate > No </ HasEndDate >
        //< Tasks >

        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public ExportTaskDto[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class ExportTaskDto
    {
        //  <Task>
        //  <Name>Broadleaf</Name>
        //  <Label>JavaAdvanced</Label>
        //</Task>
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }
}
