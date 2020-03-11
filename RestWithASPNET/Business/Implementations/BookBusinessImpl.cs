﻿using RestWithASPNET.Model;
using RestWithASPNET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Business.Implementations
{
    public class BookBusinessImpl : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public bool Exist(long? id)
        {
            return _repository.Exist(id);
        }

        public IList<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long? id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
