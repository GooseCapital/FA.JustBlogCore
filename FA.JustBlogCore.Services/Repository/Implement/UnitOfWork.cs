using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOptions<AppSettings> _appSettings;

        public UnitOfWork(JustBlogCoreContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings;
        }

        protected DbContext _context;

        public IPostRepository PostRepository
        {
            get
            {
                if (this._postRepository == null)
                {
                    this._postRepository = new PostRepository(this._context);
                }

                return this._postRepository;
            }
            set
            {
                return;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new CategoryRepository(this._context);
                }

                return this._categoryRepository;
            }
            set
            {
                return;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (this._commentRepository == null)
                {
                    this._commentRepository = new CommentRepository(this._context);
                }

                return this._commentRepository;
            }
            set
            {
                return;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (this._tagRepository == null)
                {
                    this._tagRepository = new TagRepository(this._context);
                }

                return this._tagRepository;
            }
            set
            {
                return;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(this._context, this._appSettings);
                }

                return this._userRepository;
            }
            set
            {
                return;
            }
        }

        private IPostRepository _postRepository;

        private ICategoryRepository _categoryRepository;

        private ICommentRepository _commentRepository;

        private ITagRepository _tagRepository;

        private IUserRepository _userRepository;

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}