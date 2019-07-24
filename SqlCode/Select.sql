
--USE BlogPostDemo

--SELECT * FROM Tags

--SELECT * FROM BlogPost

--Select Tags.Id, Tags.Name 
--                FROM Tags 
--                WHERE Tags.Name = 'C#'

--						SELECT BlogPost.Id, BlogPost.Author, BlogPost.Title, BlogPost.Content, Tags.Name, Comment.Id, Comment.CommentText
--                        FROM BlogPost
--                        join PostTags on PostTags.PostId = BlogPost.Id
--                        join Tags on Tags.Id = PostTags.TagId
--                        join Comment on Comment.PostId = BlogPost.Id
--                        WHERE BlogPost.Id=1

--						Select * From Comment