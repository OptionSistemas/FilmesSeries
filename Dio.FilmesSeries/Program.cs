using Dio.FilmesSeries.Classes;
using Dio.FilmesSeries.Enums;
using System;

namespace Dio.FilmesSeries
{
	class Program
	{
		static FilmeSerieRepositorio repositorio = new FilmeSerieRepositorio();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarFilmesSeries();
						break;
					case "2":
						InserirFilmesSerie();
						break;
					case "3":
						AtualizarFilmeSerie();
						break;
					case "4":
						ExcluirFilmeSerie();
						break;
					case "5":
						VisualizarFilmeSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ExcluirFilmeSerie()
		{
			Console.Write("Digite o id do filme/série: ");
			int indiceFilmeSerie = int.Parse(Console.ReadLine());

			repositorio.Excluir(indiceFilmeSerie);
		}

		private static void VisualizarFilmeSerie()
		{
			Console.Write("Digite o id do filme/série: ");
			int indiceFilmeSerie = int.Parse(Console.ReadLine());

			var filmeserie = repositorio.RetornaPorId(indiceFilmeSerie);

			Console.WriteLine(filmeserie);
		}

		private static void AtualizarFilmeSerie()
		{
			Console.Write("Digite o id do filme/série: ");
			int indiceFilmeSerie = int.Parse(Console.ReadLine());


			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());


			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme ou Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do Filme ou de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme/Série: ");
			string entradaDescricao = Console.ReadLine();

			FilmeSerie atualizaFilmeSerie = new FilmeSerie(id: indiceFilmeSerie,
				                        tipo: (Tipo)entradaTipo,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceFilmeSerie, atualizaFilmeSerie);
		}
		private static void ListarFilmesSeries()
		{
			Console.WriteLine("Listar filmes/séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme ou série cadastrada.");
				return;
			}

			foreach (var filmeserie in lista)
			{
				var excluido = filmeserie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} - Tipo: {2} {3}", filmeserie.retornaId(), filmeserie.retornaTitulo(), filmeserie.Tipo,
					(excluido ? "*Excluído*" : ""));
			}
		}

		private static void InserirFilmesSerie()
		{
			Console.WriteLine("Inserir novo filme/série");

			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());



			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme/Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do Filme ou de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme/Série: ");
			string entradaDescricao = Console.ReadLine();

			FilmeSerie novaSerie = new FilmeSerie(id: repositorio.ProximoId(),
				                        tipo: (Tipo) entradaTipo,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Filmes e Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar filmes/séries");
			Console.WriteLine("2- Inserir novo filme/série");
			Console.WriteLine("3- Atualizar filme/série");
			Console.WriteLine("4- Excluir filme/série");
			Console.WriteLine("5- Visualizar filme/série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
