using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace Backend.Models
{
    public class IMDBPost
    {
        public string title { get; set; }
        public string actors { get; set; }
        public string producer { get; set; }
        public string comments { get; set; }

        public bool flag;
        internal AppDB Db { get; set; }
        //Null Constructor
        public IMDBPost()
        {

        }

        //Valid parameter constructor to pass and view the values
        public IMDBPost(AppDB db)
        {
            Db = db;
        }

        //Insert new movies
        public async Task insertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `imdb`(`title`,`actors`,`producer`,`comments`) VALUES(@title,@actors,@producer,@comments);";
            flag = true;
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            flag = false;
        }

        //Update Actors for the movie with title

        public async Task updateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `imdb` SET `actors`=@actors,`producer`=@producer WHERE `title`=@title;";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        //Update Producer name for the movie with title

        public async Task updateProducerAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText= @"UPDATE `imdb` SET `producer`=@producer WHERE `title`=@title;";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        //Delete Movie 

        public async Task deleteMovieAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `imdb` WHERE `title`=@title;";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        
        private void BindParams(MySqlCommand command)
        {
            command.Parameters.Add(new MySqlParameter
                {
                    ParameterName="@title",
                    DbType=System.Data.DbType.String,
                    Value=title,
                });
            
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName="@actors",
                DbType=System.Data.DbType.String,
                Value=actors,
            });

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@producer",
                DbType = System.Data.DbType.String,
                Value=producer,
            });

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName="@comments",
                DbType=System.Data.DbType.String,
                Value=comments,
            });
        }
    }
}
