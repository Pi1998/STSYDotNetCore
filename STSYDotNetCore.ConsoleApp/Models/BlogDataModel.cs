using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace STSYDotNetCore.ConsoleApp.Models
{
    public class BlogDapperDataModel
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
        public int DeleteFlag { get; set; }

    } //Dapper doesn’t care about [Key] or [Column] attributes.
//It just matches property names with SQL column names automatically.



    [Table("Tbl_Blog")]//db ka column ty nae name m tu yin d lo assign lote pyy lo ya tl
    public class BlogDataModel
    {
        [Key] // primary key thet mhat trr
        [Column("BlogId")]
        public int BlogId { get; set; }

        [Column("BlogTitle")]
        public string BlogTitle { get; set; }

        [Column("BlogAuthor")]
        public string BlogAuthor { get; set; }

        [Column("BlogContent")]
        public string BlogContent { get; set; }

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; }

    }
    //EF needs metadata ([Key], [Table], [Column]) to know:
//Which table to map(Tbl_Blog).
//Which column matches which property.
//Which property is the primary key
}
