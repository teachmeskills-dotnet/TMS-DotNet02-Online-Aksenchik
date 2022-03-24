using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace CourseProject.Mvc2
{
    public class xml
    {
        public string XmlDoc()
        {
            XDocument xdoc = XDocument.Load("people.xml");
            // получаем корневой узел
            XElement? people = xdoc.Element("rating");
            if (people is not null)
            {
                // проходим по всем элементам person
                foreach (XElement person in people.Elements("person"))
                {

                    XAttribute? name = person.Attribute("name");
                    XElement? company = person.Element("company");
                    XElement? age = person.Element("age");
                }
            }
            return "0";
        }
    }
}
