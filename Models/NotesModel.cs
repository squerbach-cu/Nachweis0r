using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;

namespace Nachweis0r.Models;

public class NotesModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Note { get; set; }
    public DateTime CreatedDataTime { get; set; } = DateTime.Now;
    [ForeignKey("UserId")]
    public User User { get ; set; }
}