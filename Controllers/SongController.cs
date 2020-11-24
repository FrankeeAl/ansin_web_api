using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.WebPages;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
    public class SongController : ApiController
    {
        SDWebApiDbContext _db = new SDWebApiDbContext();
        
        [HttpGet]
        public IHttpActionResult GetAll(string search = "", string artists = "", int ? year = null, int ? peak = null )
        {
            List<Song> songs;
            if (string.IsNullOrWhiteSpace(search ))
            { 
                songs = _db.Songs.ToList();
            }
            else
            {
               songs = _db.Songs.Where(s => 
                                        s.Title.ToLower().Contains(search.ToLower())
                                        || s.Artist.ToLower().Contains(search.ToLower())
                                        ).OrderBy(o => o.Title.ToLower()).ToList();
            }

            if (!string.IsNullOrWhiteSpace(artists))
            {
                songs = songs.Where(k => k. Artist.ToLower() == artists).ToList();
            }
            if (peak != null)
            {
                songs = songs.Where(x => x.PeakChartPosition <= peak).ToList();
            }
            if (year != null)
            {
                songs = songs.Where(x => x.ReleaseYear == year).ToList();
            }

            int totalSongs = songs.Count();

            return Ok( new { totalSongs, songs});
        }
        [HttpPost]
        public IHttpActionResult Create([FromBody]Song song)
        {
            _db.Songs.Add(song);
            _db.SaveChanges();
            return Ok("Successfully Added " + "Song Id" + song.Id);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]Song updatedSong)
        {
            var song = _db.Songs.Find(updatedSong.Id);
            if (song != null)
            {
                song.Artist = updatedSong.Artist;
                song.Title = updatedSong.Title;
                song.Genre = updatedSong.Genre;
                song.ReleaseYear = updatedSong.ReleaseYear;
                song.PeakChartPosition = updatedSong.PeakChartPosition;
                _db.Entry(song).State = EntityState.Modified;
                _db.SaveChanges();

                return Ok(song);
            }
            else
            {
                return BadRequest("Song not found");
            }

        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var songToDelete = _db.Songs.Find(Id);
            if (songToDelete != null)
            {
                _db.Songs.Remove(songToDelete);
                _db.SaveChanges();
                return Ok("Successfully Deleted.");
            }
            else
                return BadRequest("Song not found.");
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var song = _db.Songs.Find(id);
            if (song != null)
                return Ok(song);
            else
                return BadRequest("Song not found.");
        }
    }
}
