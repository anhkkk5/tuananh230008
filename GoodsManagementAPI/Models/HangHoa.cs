using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsManagementAPI.Models
{
    public class HangHoa
    {
        [Key]
        [StringLength(9)]
        public string MaHangHoa { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string TenHangHoa { get; set; } = string.Empty;

        public int SoLuong { get; set; }

        public string? GhiChu { get; set; }
    }
}
