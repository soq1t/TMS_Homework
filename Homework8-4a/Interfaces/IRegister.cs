using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework8_4a.Models.Documents;

namespace Homework8_4a.Interfaces
{
    internal interface IRegister
    {
        bool AddDocument(Document document);
        bool PrintDocumentInfo();
    }
}
