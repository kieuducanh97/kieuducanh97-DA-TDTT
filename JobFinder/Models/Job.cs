using System.ComponentModel.DataAnnotations;

namespace JobFinder.Models;

public class Job
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tiêu đề việc làm là bắt buộc.")]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mô tả là bắt buộc.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tên công ty là bắt buộc.")]
    [StringLength(120)]
    public string Company { get; set; } = string.Empty;

    [Required(ErrorMessage = "Địa điểm là bắt buộc.")]
    [StringLength(120)]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mức lương là bắt buộc.")]
    [StringLength(80)]
    public string Salary { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Type { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime PostedDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime Deadline { get; set; }

    [Required]
    [StringLength(100)]
    public string Experience { get; set; } = string.Empty;

    [Required]
    [StringLength(80)]
    public string Level { get; set; } = string.Empty;

    public bool IsRemote { get; set; }

    [StringLength(300)]
    public string CompanyLogoUrl { get; set; } = string.Empty;

    [Required]
    public string Responsibilities { get; set; } = string.Empty;

    [Required]
    public string Requirements { get; set; } = string.Empty;
}
