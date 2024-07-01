using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3v2.Models
{
    public class Joke
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string JokeText { get; set; }
        public string Code { get; set; }
        public string LeninCando { get; set; }
    }


}
