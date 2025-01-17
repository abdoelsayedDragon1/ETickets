﻿using ETickets.Models;

namespace ETickets.Repository.IRepository
{
    public interface IMovieRepository: IRepository<Movie>
    {
        Movie GetMovieWithDetails(int id);
    }
}
