using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;
public class CategoryModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public bool IsMain { get; set; }
}

public class CategoryPostModel
{
    [Required]
    public int Id { get; set; }
}
