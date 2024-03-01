CREATE TABLE Anagrafica(
	[IdAnagrafica] [int] IDENTITY(1,1) NOT NULL,
	[Cognome] [nvarchar](30) NOT NULL,
	[Nome] [nvarchar](30) NOT NULL,
	[Indirizzo] [nvarchar](50) NULL,
	[Citta] [nvarchar](20) NULL,
	[CAP] [char](5) NOT NULL,
	[Cod_Fisc] [char](16) NOT NULL,
 CONSTRAINT [PK_Anagrafica] PRIMARY KEY CLUSTERED 
(
	[IdAnagrafica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE TipoViolazione(
	[IdViolazione] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TipoViolazione] PRIMARY KEY CLUSTERED 
(
	[IdViolazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE Verbale(
	[IdVerbale] [int] IDENTITY(1,1) NOT NULL,
	[DataViolazione] [smalldatetime] NOT NULL,
	[IndirizzoViolazione] [nvarchar](50) NULL,
	[Nominativo_Agente] [char](6) NOT NULL,
	[DataTrascrizioneVerbale] [smalldatetime] NULL,
	[Importo] [smallmoney] NOT NULL,
	[DecurtamentoPunti] [int] NULL,
	[AnagraficaId] [int] NOT NULL,
	[TipoViolazioneId] [int] NOT NULL,
 CONSTRAINT [PK_Verbale] PRIMARY KEY CLUSTERED 
(
	[IdVerbale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Verbale] ADD  CONSTRAINT [DF_Verbale_Importo]  DEFAULT ((0)) FOR [Importo]
GO

ALTER TABLE [dbo].[Verbale]  WITH CHECK ADD  CONSTRAINT [FK_Verbale_Anagrafica] FOREIGN KEY([AnagraficaId])
REFERENCES [dbo].[Anagrafica] ([IdAnagrafica])
GO

ALTER TABLE [dbo].[Verbale] CHECK CONSTRAINT [FK_Verbale_Anagrafica]
GO

ALTER TABLE [dbo].[Verbale]  WITH CHECK ADD  CONSTRAINT [FK_Verbale_TipoViolazione] FOREIGN KEY([TipoViolazioneId])
REFERENCES [dbo].[TipoViolazione] ([IdViolazione])
GO

ALTER TABLE [dbo].[Verbale] CHECK CONSTRAINT [FK_Verbale_TipoViolazione]
GO


