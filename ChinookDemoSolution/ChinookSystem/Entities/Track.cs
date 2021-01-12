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
	internal class Track
	{

		private string _Composer;
		
		[Key]
		public int TrackId { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[StringLength(200, ErrorMessage = "Track name is limited to 200 characters.")]
		public string Name { get; set; }

		//nullable FK
		public int? AlbumId { get; set; }

		//FK
		public int MediaTypeId { get; set; }

		public int GenreId { get; set; }

		[StringLength(220, ErrorMessage = "Composer name is limited to 220 characters.")]
		public string Composer
		{
			get { return _Composer; }
			set { _Composer = string.IsNullOrEmpty(value) ? null : value; }
		}

		//[Required(ErrorMessage = "Milliseconds is required.")] //default value of a nnumeric value is 0
		public int Milliseconds { get; set; }

		public int? Bytes { get; set; }

		
		//[RegularExpression()].....decimal(10,2)use \b\d{1,10}\.\d{1,2}\b do it in presentation layer... database should not do presentation work
		public decimal UnitPrice { get; set; }

		//navigation
		public virtual Album Album { get; set; }
		public virtual Genre Genre { get; set; }
		public virtual MediaType MediaType { get; set; }

	}
}
