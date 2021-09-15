USE [BDAfiliado]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetListAfiliado]    Script Date: 14/09/2021 2:08:33 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetListAfiliado]
    @City varchar(max) = '',
    @Year int = 0
AS

IF ISNULL(@City,'')!='' AND ISNULL(@Year,0)=0
BEGIN
    SELECT
    	Af.AfiliadoID,
    	Af.AfiliadoNombre,
    	Af.FechaNacimiento,
    	Af.LugarNacimiento,
        Af.Foto,
    (SELECT CONVERT (VARCHAR(MAX), CAST('' AS XML).value('xs:base64Binary(sql:column("Foto"))', 'VARBINARY(MAX)')) AS FotoBase64 FROM
    Afiliado
     WHERE Afiliado.AfiliadoID = Af.AfiliadoID) AS FotoBase64,
        Af.Peso
    FROM
    	Afiliado Af 
    WHERE Af.LugarNacimiento = @City
END
ELSE IF ISNULL(@Year,0)!=0 AND ISNULL(@City,'')=''
BEGIN
    SELECT
    	Af.AfiliadoID,
    	Af.AfiliadoNombre,
    	Af.FechaNacimiento,
    	Af.LugarNacimiento,
    	Af.Foto,
    (SELECT CONVERT (VARCHAR(MAX), CAST('' AS XML).value('xs:base64Binary(sql:column("Foto"))', 'VARBINARY(MAX)')) AS FotoBase64 FROM
    Afiliado
     WHERE Afiliado.AfiliadoID = Af.AfiliadoID) AS FotoBase64,
        Af.Peso
    FROM
    	Afiliado Af 
    WHERE YEAR(Af.FechaNacimiento) = @Year
END
ELSE
BEGIN
    SELECT
    	Af.AfiliadoID,
    	Af.AfiliadoNombre,
    	Af.FechaNacimiento,
    	Af.LugarNacimiento,
    	Af.Foto,
    (SELECT CONVERT (VARCHAR(MAX), CAST('' AS XML).value('xs:base64Binary(sql:column("Foto"))', 'VARBINARY(MAX)')) AS FotoBase64 FROM
    Afiliado
     WHERE Afiliado.AfiliadoID = Af.AfiliadoID) AS FotoBase64,
        Af.Peso
    FROM
    	Afiliado Af
    WHERE YEAR(Af.FechaNacimiento) = @Year AND Af.LugarNacimiento = @City
END
GO