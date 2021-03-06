USE [BaseTesteJet]
GO
/****** Object:  Table [dbo].[Carrinho]    Script Date: 21/12/2017 07:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrinho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataCadastro] [date] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_Carrinho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarrinhoItens]    Script Date: 21/12/2017 07:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrinhoItens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCarrinho] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[ValorUnitario] [float] NOT NULL,
	[ValorTotalItem] [float] NOT NULL,
	[Quantidade] [int] NOT NULL,
	[DataCadastro] [date] NOT NULL,
 CONSTRAINT [PK_CarrinhoItens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 21/12/2017 07:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[DataCadastro] [date] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 21/12/2017 07:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](300) NOT NULL,
	[Email] [varchar](300) NOT NULL,
	[DataCadastro] [date] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 21/12/2017 07:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [float] NOT NULL,
	[IdCarrinho] [int] NOT NULL,
	[DataCadastro] [date] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoItens]    Script Date: 21/12/2017 07:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoItens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NOT NULL,
	[ValorTotal] [float] NOT NULL,
	[ValorUnidade] [float] NOT NULL,
	[Quantidade] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[DataCadastro] [date] NOT NULL,
 CONSTRAINT [PK_PedidoItens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 21/12/2017 07:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](300) NOT NULL,
	[Descricao] [varchar](800) NULL,
	[Ativo] [bit] NOT NULL,
	[Preco] [float] NOT NULL,
	[PrecoPromocional] [float] NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdutoCategoria]    Script Date: 21/12/2017 07:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdutoCategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[DataCadastro] [date] NOT NULL,
 CONSTRAINT [PK_ProdutoCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrinho]  WITH CHECK ADD  CONSTRAINT [FK_Carrinho_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Carrinho] CHECK CONSTRAINT [FK_Carrinho_Cliente]
GO
ALTER TABLE [dbo].[CarrinhoItens]  WITH CHECK ADD  CONSTRAINT [FK_CarrinhoItens_Carrinho] FOREIGN KEY([IdCarrinho])
REFERENCES [dbo].[Carrinho] ([Id])
GO
ALTER TABLE [dbo].[CarrinhoItens] CHECK CONSTRAINT [FK_CarrinhoItens_Carrinho]
GO
ALTER TABLE [dbo].[CarrinhoItens]  WITH CHECK ADD  CONSTRAINT [FK_CarrinhoItens_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[CarrinhoItens] CHECK CONSTRAINT [FK_CarrinhoItens_Produto]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Carrinho] FOREIGN KEY([IdCarrinho])
REFERENCES [dbo].[Carrinho] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Carrinho]
GO
ALTER TABLE [dbo].[PedidoItens]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItens_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[PedidoItens] CHECK CONSTRAINT [FK_PedidoItens_Pedido]
GO
ALTER TABLE [dbo].[ProdutoCategoria]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoCategoria_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[ProdutoCategoria] CHECK CONSTRAINT [FK_ProdutoCategoria_Categoria]
GO
ALTER TABLE [dbo].[ProdutoCategoria]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoCategoria_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[ProdutoCategoria] CHECK CONSTRAINT [FK_ProdutoCategoria_Produto]
GO
