USE keeprvault333;

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps
-- ( 
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   img VARCHAR(255) NOT NULL,
--   views INT,
--   shares INT,
--   keeps INT,
--   creatorId VARCHAR(255) NOT NULL, 
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE
-- );
--  TRUNCATE TABLE vaults;
-- CREATE TABLE vaults 
-- ( 
--   id INT NOT NULL AUTO_INCREMENT, 
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   isPrivate TINYINT(0),
--   creatorId VARCHAR(255) NOT NULL, 
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE
-- );

-- CREATE TABLE vaultkeeps
-- (
--   id INT NOT NULL AUTO_INCREMENT, 
--   keepId INT,
--   vaultId INT,
--   creatorId VARCHAR(255),
--   PRIMARY KEY (id),

--    FOREIGN KEY (creatorId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE,

--   FOREIGN KEY (keepId)
--    REFERENCES keeps (id)
--    ON DELETE CASCADE,

--   FOREIGN KEY (vaultId)
--    REFERENCES vaults (id)
--    ON DELETE CASCADE

-- )