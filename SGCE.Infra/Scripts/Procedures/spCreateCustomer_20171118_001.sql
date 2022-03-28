CREATE PROCEDURE spCreateCliente
    @Id UNIQUEIDENTIFIER,
    @FirstNome VARCHAR(40),
    @LastNome VARCHAR(40),
    @Document CHAR(11),
    @Email VARCHAR(160),
    @Phone VARCHAR(13)
AS
    INSERT INTO [Cliente] (
        [Id], 
        [FirstNome], 
        [LastNome], 
        [Document], 
        [Email], 
        [Phone]
    ) VALUES (
        @Id,
        @FirstNome,
        @LastNome,
        @Document,
        @Email,
        @Phone
    )