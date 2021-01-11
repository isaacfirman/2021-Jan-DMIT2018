using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.Entities
{
	//the only way to access INTERNAL is if you are inside the library
	[Table("Artists")] //artists is the name of the sql table
	internal class Artist
	{
		private string _Name;

		[Key] //identity
		public int ArtistId { get; set; }

		//[Required(ErrorMessage = "Artist name is required")]
		[StringLength(120, ErrorMessage = "Artist name is limited to 120 characters.")]
		public string Name //nullable
		{
			get { return _Name; }
			set { _Name = string.IsNullOrEmpty(value) ? null : value;  }
		}
	}
}
