﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional namespaces
using ChinookSystem.Entities;
using ChinookSystem.DAL;
using ChinookSystem.ViewModels;
using System.ComponentModel; //is for ODS
#endregion

namespace ChinookSystem.BLL
{
	[DataObject] //available in the web app
	public class AlbumController
	{
		//because entities are internal, you cant use entities as a return datatype
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public List<ArtistAlbums> Albums_GetArtistAlbums() 
		{
			using (var context = new ChinookSystemContext())
			{
				//use LINQ to Entity
				IEnumerable<ArtistAlbums> results = from x in context.Albums
													select new ArtistAlbums
													{
														Title = x.Title,
														ReleaseYear = x.ReleaseYear,
														ArtistName = x.Artist.Name
													};
				return results.ToList();
			}
		}
	}
}
