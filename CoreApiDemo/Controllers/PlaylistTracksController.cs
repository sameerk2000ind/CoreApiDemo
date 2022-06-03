﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreApiDemo.Repository;
using CoreApiDemo.Repository.Models;

namespace CoreApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistTracksController : ControllerBase
    {
        private readonly ChinookDBContext _context;

        public PlaylistTracksController(ChinookDBContext context)
        {
            _context = context;
        }

        // GET: api/PlaylistTracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistTrack>>> GetPlaylistTracks()
        {
            return await _context.PlaylistTracks.ToListAsync();
        }

        // GET: api/PlaylistTracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistTrack>> GetPlaylistTrack(int id)
        {
            var playlistTrack = await _context.PlaylistTracks.FindAsync(id);

            if (playlistTrack == null)
            {
                return NotFound();
            }

            return playlistTrack;
        }

        // PUT: api/PlaylistTracks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylistTrack(int id, PlaylistTrack playlistTrack)
        {
            if (id != playlistTrack.PlaylistId)
            {
                return BadRequest();
            }

            _context.Entry(playlistTrack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistTrackExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlaylistTracks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlaylistTrack>> PostPlaylistTrack(PlaylistTrack playlistTrack)
        {
            _context.PlaylistTracks.Add(playlistTrack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylistTrack", new { id = playlistTrack.PlaylistId }, playlistTrack);
        }

        // DELETE: api/PlaylistTracks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlaylistTrack>> DeletePlaylistTrack(int id)
        {
            var playlistTrack = await _context.PlaylistTracks.FindAsync(id);
            if (playlistTrack == null)
            {
                return NotFound();
            }

            _context.PlaylistTracks.Remove(playlistTrack);
            await _context.SaveChangesAsync();

            return playlistTrack;
        }

        private bool PlaylistTrackExists(int id)
        {
            return _context.PlaylistTracks.Any(e => e.PlaylistId == id);
        }
    }
}
