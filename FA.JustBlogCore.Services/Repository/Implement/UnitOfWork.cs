using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(JustBlogCoreContext context)
        {
            _context = context;
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

        private IPostRepository _postRepository;

        private ICategoryRepository _categoryRepository;

        private ICommentRepository _commentRepository;

        private ITagRepository _tagRepository;

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