﻿using System;
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
	[Table("Albums")]
	internal class Album
	{
		private string _ReleaseLabel;
		private int _ReleaseYear;

		[Key]
		public int AlbumId { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		[StringLength(160, ErrorMessage = "Album title is limited to 160 characters.")]
		public string Title { get; set; }

		//if the name of FK is the same as the primary table, you dont need to annotate [ForeignKey]
		public int ArtistId { get; set; }

		//default value of any numeric is 0, so no need to put [Required]
		public int ReleaseYear 
		{
			get { return _ReleaseYear; }
			set {
				if (_ReleaseYear < 1950 || _ReleaseYear > DateTime.Today.Year)
				{
					throw new Exception("Album release year is before 1950 or a year in the future.");
				}
				else { _ReleaseYear = value; }
			}
		}

		[StringLength(50, ErrorMessage = "Album title is limited to 50 characters.")]
		public string ReleaseLabel //nullable
		{
			get { return _ReleaseLabel;  }
			set { _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value; }
		}

		//navigational properties
		//link Album table to Artist table
		//virtual is always used for navigational properties
		//many to 1 relationship
		//create one end of the relationship in this entity
		public virtual Artist Artist { get; set; }
		public virtual ICollection<Track> Tracks { get; set; }
	}
}
