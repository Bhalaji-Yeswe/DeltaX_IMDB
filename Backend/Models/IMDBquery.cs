using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace Backend.Models
{
    public class IMDBquery
    {
        public AppDB Db { get; }

        public IMDBquery(AppDB db)
        {
            Db = db;
        }

        public async Task<IMDBPost> FindOneAsync(string title)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `title`,`actors`, `producer`,`comments` FROM `imdb` WHERE `title` = @title";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@title",
                DbType = System.Data.DbType.String,
                Value = title,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<IMDBPost>> latestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `title`, `actors`, `producer`,`comments` FROM `imdb`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private async Task<List<IMDBPost>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<IMDBPost>();
            using(reader)
            {
                while(await reader.ReadAsync())
                {
                    var post = new IMDBPost(Db)
                    {
                        title = reader.GetString(0),
                        actors = reader.GetString(1),
                        producer = reader.GetString(2),
                        comments = reader.GetString(3),
                    };
                    posts.Add(post);
                }

            }
            return posts;
        }
    }
}
