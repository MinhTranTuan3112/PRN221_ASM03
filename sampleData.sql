USE PostManagementDb;
INSERT INTO PostCategories (CategoryName, [Description])
VALUES
('Technology', 'Posts related to technology, software, hardware, etc.'),
('Sports', 'Posts about various sports and athletic activities.'),
('Travel', 'Posts documenting travel experiences and destinations.'),
('Food', 'Posts about cooking, recipes, restaurants, and food culture.'),
('Entertainment', 'Posts covering movies, TV, music, games, and other entertainment.');


INSERT INTO AppUsers (Fullname, [Address], Email, [Password])
VALUES
('John Doe', '123 Main St, Anytown USA', 'john.doe@example.com', 'Password123!'),
('Jane Smith', '456 Oak Rd, Smallville', 'jane.smith@example.com', 'ILoveChocolate7'),
('Michael Johnson', '789 Elm Ct, Bigcity', 'mjohnson@example.net', 'Abc12345!'),
('Sarah Lee', '321 Pine Ave, Suburbia', 'slee@example.org', 'HelloWorld99'),
('David Brown', '159 Maple Ln, Ruraltown', 'dbrown@example.co.uk', 'P@ssw0rd1234');


INSERT INTO Posts (AuthorID, CreatedDate, UpdatedDate, Title, Content, PublishStatus, CategoryID)
VALUES
(1, '2023-05-15', '2023-05-16', 'The Future of Quantum Computing', 'Quantum computers have the potential to revolutionize computing with their ability to perform certain tasks exponentially faster than classical computers...', 'Published', 1),
(2, '2023-07-01', '2023-07-02', 'Top 10 Hiking Trails in Colorado', 'From the majestic Rocky Mountains to the serene alpine lakes, Colorado offers some of the best hiking experiences in the United States. In this post, we''ll explore 10 of the most breathtaking trails that should be on every outdoor enthusiast''s bucket list...', 'Published', 3),
(3, '2023-09-20', '2023-09-21', 'The Art of Sushi Making', 'Sushi is a beloved culinary art form that has gained global popularity. In this comprehensive guide, we''ll dive into the intricate techniques and traditions of sushi making, revealing the secrets behind crafting mouthwatering sushi masterpieces...', 'Published', 4),
(4, '2023-11-01', '2023-11-03', 'The Rise of Esports', 'Esports, the competitive world of video gaming, has experienced a meteoric rise in recent years, captivating audiences around the globe. In this post, we explore the history, the top games, and the impact of this rapidly growing industry...', 'Published', 5),
(5, '2024-01-15', '2024-01-16', 'The Science Behind Marathons', 'Running a marathon is an incredible feat of endurance and determination. In this article, we delve into the science behind marathon running, exploring the physiological and psychological challenges faced by athletes and the training strategies that help them conquer 26.2 miles...', 'Draft', 2);

