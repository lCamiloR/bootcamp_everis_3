using System;

namespace PrimeirosPassosDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            string opcaoUsuario = ExtrairOpcaoUsuario();
            int indiceAluno = 0;

            while (opcaoUsuario.ToUpper() != "X")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        //TODO: adicionar aluno
                        Aluno aluno = new Aluno();
                        Console.WriteLine("Informe a o nome do aluno:");
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal!");
                        }

                        if (indiceAluno < 5)
                        {
                            alunos[indiceAluno] = aluno;
                            indiceAluno++;
                        }
                        else
                        {
                            throw new IndexOutOfRangeException("maximo de alunos cadastrados!");
                        }

                        break;
                    case "2":
                        //TODO: listar alunos
                        foreach (Aluno a in alunos)
                        {
                            if (a == null) continue;
                            Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}");
                        }
                        break;
                    case "3":
                        //TODO: calcular a média geral
                        int quantAlunos = 0;
                        decimal somaTotal = 0;
                        foreach (Aluno a in alunos)
                        {
                            if (a == null) continue;
                            quantAlunos++;
                            somaTotal += a.Nota;
                        }

                        var mediaGeral = somaTotal / quantAlunos;

                        Console.WriteLine($"Média Geral: {mediaGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ExtrairOpcaoUsuario();

            }


        }

        private static string ExtrairOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair do sistema");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();

            return opcaoUsuario;
        }
    }
}
