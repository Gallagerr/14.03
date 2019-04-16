using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul18
{
  [Serializable]
  public class Book
  {
    public string Name { get; set; }
    public int Price { get; set; }
    public string AuthorName { get; set; }
    public DateTime Year { get; set; }
  }
}
