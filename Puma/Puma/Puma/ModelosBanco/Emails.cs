using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Puma.ModelosBanco
{
    [Table("Emails")]
    public class Emails
    {
        [PrimaryKey]
        public string Email { get; set; }
    }
}
