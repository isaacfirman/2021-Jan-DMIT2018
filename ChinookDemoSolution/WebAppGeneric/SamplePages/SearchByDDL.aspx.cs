
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region additional namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion
namespace WebAppGeneric.SamplePages
{
	public partial class SearchByDDL : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//this is first time
				LoadArtistList();
			}

		}

		protected void LoadArtistList()
		{
			ArtistController sysmgr = new ArtistController();
			List<SelectionList> info = sysmgr.Artists_DDLList();

			//lets assume data collection needs to be sorted (ascending order)
			// for x and y, do the following...
			//lambda (=>) will supply the delegate (on the right side of =>)
			//compare x display field to y display field
			info.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField));

			//setup the ddl
			ArtistList.DataSource = info;
			ArtistList.DataTextField = nameof(SelectionList.DisplayField);
			ArtistList.DataValueField = nameof(SelectionList.ValueField);
			ArtistList.DataBind();

			//setup of a prompt line, at position 0...
			ArtistList.Items.Insert(0, new ListItem("Please select...", "0"));
		}

		protected void SearchAlbums_Click(object sender, EventArgs e)
		{
			if (ArtistList.SelectedIndex == 0)
			{
				MessageLabel.Text = "Please select an artist!!!";
				ArtistAlbumList.DataSource = null;
				ArtistAlbumList.DataBind();
			}
			else 
			{
				MessageLabel.Text = "";
				//show the gridview
				AlbumController sysmgr = new AlbumController();
				List<ChinookSystem.ViewModels.ArtistAlbums> info = sysmgr.Albums_GetAlbumsForArtist(int.Parse(ArtistList.SelectedValue));
				ArtistAlbumList.DataSource = info;
				ArtistAlbumList.DataBind();
			}
		}
	}
}