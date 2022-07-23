﻿using MyWebApp.Data.Entities;
using MyWebApp.Domain.Exceptions;
using MyWebApp.Domain.Repositories;

namespace MyWebApp.Domain.Services;

public sealed class UserService
{
    private readonly UserRepository _repo;


    public UserService(string connectionString) => _repo = new UserRepository(connectionString);

    public async Task<User> GetById(ulong id)
    {
        var user = await _repo.GetByIdAsync(id);

        if (user is null) throw new EntityNotFoundException();

        return user;
    }

    public async Task<User> GetByName(string name)
    {
        var user = await _repo.GetByName(name);

        return user;
    }
}