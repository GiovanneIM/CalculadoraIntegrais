using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_Forms
{
    public partial class Form1 : Form
    {
        // CRIANDO VARIÁVEIS DO GRÁFICO

        // Modelo do gráfico
        PlotModel plotModel = new PlotModel { Title = "Gráfico" };

        LineSeries inicio = new LineSeries { Color = OxyColors.Red }; // Série do inicio do intervalo
        LineSeries final = new LineSeries { Color = OxyColors.Red };  // Série do final do intervalo

        // Eixo X do gráfico
        LinearAxis eixoX = new LinearAxis 
        {
            Position = AxisPosition.Bottom,
            PositionAtZeroCrossing = true,   // Faz com que os eixos se cruzem em (0,0)
            AxislineStyle = LineStyle.Solid  // Faz com que a linha do eixo seja sólida
        };
        // Eixo Y do gráfico
        LinearAxis eixoY = new LinearAxis 
        { 
            Position = AxisPosition.Left,
            PositionAtZeroCrossing = true,   // Faz com que os eixos se cruzem em (0,0)
            AxislineStyle = LineStyle.Solid  // Faz com que a linha do eixo seja sólida
        };

        // Série de pontos da função
        LineSeries seriefuncao = new LineSeries 
        {
            Color = OxyColors.DarkBlue, 
            LineStyle = LineStyle.Solid 
        };
        // Série de pontos auxiliar para a função
        LineSeries seriefuncaoaux = new LineSeries { };

        // Série de ponto para definição Área
        AreaSeries areaSeries = new AreaSeries 
        {
            Color = OxyColors.LightBlue,  // Cor da área preenchida
            StrokeThickness = 0,          // Espessura da linha que contorna a área prenchida
        };
        // ================================================================================================================================
        
        // INTERFACE

        public Form1()
        {
            InitializeComponent();

            // Adicionando o Modelo (gráfico) ao PlotView (tela)
            ptv_Grafico.Model = plotModel;

            // Adicionando os eixos ao gráfico
            plotModel.Axes.Add(eixoX);
            plotModel.Axes.Add(eixoY);

            // Adicionando as séries do intervalo ao gráfico
            plotModel.Series.Add(inicio);
            plotModel.Series.Add(final);

            // Adicionando a série da função ao gráfico
            plotModel.Series.Add(seriefuncao);

            // Adicionando a série da área ao gráfico
            plotModel.Series.Add(areaSeries);

            // Modifica o texto do Label saída
            lbl_saída.Text = "INTEGRAL\n";
        }

        public void btn_CalcIntegral_Click(object sender, EventArgs e)
        {
            /* O que acontece quando o usuário aperta o botão "Calcular Integral" */

            // --- REINICIANDO SÉRIES

            // Esvaziando as séries de função
            seriefuncao.Points.Clear();
            seriefuncaoaux.Points.Clear();

            // Esvaziando as séries do intervalo
            inicio.Points.Clear();
            final.Points.Clear();

            // Esvaziando a série da área
            areaSeries.Points.Clear();
            areaSeries.Points2.Clear();


            // --- OBTENDO DADOS

            // Obtendo os dados fornecidos pelo usuário
            string funcao = txtB_Funcao.Text.Replace(" ", "");
            double[] entradas = { StringParaDecimal(txtB_InicioIntervalo.Text), StringParaDecimal(txtB_FinalIntervalo.Text), double.Parse(txtB_Divisoes.Text) };


            // --- TRATANDO DADOS 

            // Calculando a integral
            double integral = CalcularIntegral(funcao, entradas);

            Area(entradas);

            // Definindo Intervalos
            Intervalo(entradas[0], entradas[1]);


            // --- SAÍDA DE DADOS

            // Atualizando o gráfico
            plotModel.InvalidatePlot(true);

            // Exibindo a Integral calculada para o usuário
            lbl_saída.Text = $"INTEGRAL\n{integral:0.#######}";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            /* Botão para limpar informações da tela */

            // Limpando as séries de função e intevalo
            seriefuncao.Points.Clear();
            inicio.Points.Clear();
            final.Points.Clear();

            // Limpando a série da área 
            areaSeries.Points.Clear();
            areaSeries.Points2.Clear();

            // Limpa os TextButtons 
            txtB_Funcao.Text = "";
            txtB_InicioIntervalo.Text = "";
            txtB_FinalIntervalo.Text = "";
            txtB_Divisoes.Text = "";

            // Modifica o Label de saída
            lbl_saída.Text = "INTEGRAL:\n";

            // Atualiza o gráfico
            plotModel.InvalidatePlot(true);
        }


        // ================================================================================================================================

        // FUNÇÕES DO GRÁFICO

        public void Intervalo(double inc_intervalo, double fnl_intervalo) 
        {
            /* Função que cria as demarcações do intervalo */

            double y;

            // Criando a demarcação do inicio do intervalo
            y = seriefuncao.Points[0].Y;  // y recebe o valor do 1º f(x) da série da função

            inicio.Points.Add(new DataPoint(inc_intervalo, 0));  // Adiciona o ponto (x, 0)     -> x é o inicio do intervalo
            inicio.Points.Add(new DataPoint(inc_intervalo, y));  // Adiciona o ponto (x, f(x))

            // Criando a demarcação do final do intervalo
            y = seriefuncao.Points[seriefuncao.Points.Count - 1].Y; // y recebe o valor do último f(x) da série da função

            final.Points.Add(new DataPoint(fnl_intervalo, 0));  // Adiciona o ponto (x, 0)     -> x é o fim do intervalo
            final.Points.Add(new DataPoint(fnl_intervalo, y));  // Adiciona o ponto (x, f(x))
        }

        public void AdicionarPonto(double x, double y) 
        {
            /* Adiciona ou atualiza os pontos na série da função*/

            // Se a série da função estiver vazia ou não estiver completa, adiciona o ponto diretamente a ela
            if (seriefuncao.Points.Count == 0 || seriefuncao.Points.Last().X < x)
                seriefuncao.Points.Add(new DataPoint(x, y));
            
            // Se a série da função já estiver completa, adiciona o ponto à série de ponto auxiliar
            else
                seriefuncaoaux.Points.Add(new DataPoint(x, y));

            // Quando as duas série tiverem o mesmo tamanho, significa que x é o final do intervalo
            if (seriefuncao.Points.Count == seriefuncaoaux.Points.Count)
            {
                // Soma os valores de f(x) da série auxiliar aos da série principal
                for (int i = 0; i < seriefuncaoaux.Points.Count; i++)
                {
                    seriefuncao.Points[i] = SomarY(seriefuncao.Points[i], seriefuncaoaux.Points[i]);
                }

                // Limpa a série auxiliar
                seriefuncaoaux.Points.Clear(); 
            }
        }

        public void Area(double[] intervalo) 
        {
            /* Adiciona os pontos dos limites da área*/

            // Adicionando os limites superiores (Os valores de F(x))
            for (int i = 0; i < seriefuncao.Points.Count; ++i) 
            {
                areaSeries.Points.Add(seriefuncao.Points[i]);
            }

            // Adicionando os limites inferiores (O eixo X)
            areaSeries.Points2.Add(new DataPoint(intervalo[0], 0)); // Ponto -> (IntervaloInicio, 0)
            areaSeries.Points2.Add(new DataPoint(intervalo[1], 0)); // Ponto -> (IntervaloFim, 0)
        }

        public DataPoint SomarY(DataPoint ponto1, DataPoint ponto2)
        {
            /* Soma o valor de Y do segundo ponto ao do primeiro */

            // Soma o Y dos dois pontos
            double somaY = ponto1.Y + ponto2.Y;

            // Retorna um novo DataPoint com as somas dos Y
            return new DataPoint(ponto1.X, somaY);
        }


        // ================================================================================================================================

        // FUNÇÕES DE CÁLCULO


        public double CalcularIntegral(string funcao, double[] entradas)
        {
            /* Calcula a integral de uma função, com uma ou mais parte, parte por parte */

            // Partindo a função
            string[] f_partes = QuebraFuncao(funcao);


            // Calculando a integral
            double integral_total = 0;
            double integral_parcial = 0;

            int ind = 0;
            do
            {
                string parte = f_partes[ind];

                integral_parcial = Integral(parte, entradas);

                integral_total += integral_parcial;

                ind++;
            } while (ind < f_partes.Length);

            return integral_total;
        }

        string[] QuebraFuncao(string funcao)
        {
            /* Desmembra uma função em partes de acordo com adições e subtrações 
             * 
             * Retorna um vetor com as partes
             * 
             * Ex: QuebraFuncao("Ax^2-Bx+C") -> {+Ax^2, -Bx, +c}
             */

            // Garante que o primeiro char da string função é um operador (+) ou (-)
            if (funcao[0] != '+' && funcao[0] != '-')
                funcao = "+" + funcao; // EX: 4x^2-3x+2 -> +4x^2-3x+2


            bool parenteses = false;
            int num_partes = 0;

            // Calculo do número de partes para a criação do vetor
            for (int i = 0; i < funcao.Length; i++)
            {
                // Quando o laço encontra um '+'/'-' fora de parenteses, aumenta o número de partes
                if (!parenteses && (funcao[i] == '+' || funcao[i] == '-'))
                {
                    num_partes++;
                }

                // Quando o laço acha o char '(', ele para de contar os operadores
                else if (funcao[i] == '(')
                    parenteses = true;

                // Quando o laço acha o char ')', ele volta a contar os operadores
                else if (funcao[i] == ')')
                    parenteses = false;
            }


            // vetor para receber as partes da função
            string[] f_partes = new string[num_partes];


            parenteses = false;

            // Laço que desmembra a função
            int parte_ind = 0, inicio_atual = 0;
            for (int i = 1; i < funcao.Length; i++)
            {
                // Quando o laço encontra um '+'/'-' fora de parenteses, ele quebra a função
                if (!parenteses && (funcao[i] == '+' || funcao[i] == '-'))
                {
                    f_partes[parte_ind] = funcao.Substring(inicio_atual, i - inicio_atual);
                    inicio_atual = i;
                    parte_ind++;
                }

                // Quando o laço acha o char '(', ele para de quebrar a função
                else if (funcao[i] == '(')
                    parenteses = true;

                // Quando o laço acha o char ')', ele volta a quebrar a função
                else if (funcao[i] == ')')
                    parenteses = false;
            }
            // Pega a última parte da função
            f_partes[parte_ind] = funcao.Substring(inicio_atual);


            // Laço que transforma kx em k*x
            for (int i = 0; i < f_partes.Length; i++)
            {
                for (int j = 0; j < f_partes[i].Length; j++)
                {
                    if (f_partes[i][j] == 'x' && ( char.IsDigit(f_partes[i][j - 1]) || f_partes[i][j - 1] == ')' ))
                    {
                        f_partes[i] = f_partes[i].Replace("x", "*x");
                    }
                }
            }

            // Retorna o vetor com as partes da função
            return f_partes;
        }
        
        string IdentificaFuncao(string funcao)
        {
            /* Identifica o tipo de uma função */

            if (funcao.IndexOf("sen(") != -1)
                return "SENO";

            else if (funcao.IndexOf("cos(") != -1)
                return "COSSENO";

            else if (funcao.IndexOf("e^") != -1)
                return "EXPONENCIAL";

            else if (funcao.IndexOf("x") == -1)
                return "CONSTANTE";

            return "POLINOMIAL";
        }

        public double Integral(string integrando, double[] informacoes)
        { 
            /* Cálcula a integral de uma função 
             * Integrando -> Função a ser integrada
             * Informações -> vetor contendo x inicial, x final  e o número de divisões
             */

            // Separando o operador '+'/'-' do resto do integrando
            char operador = integrando[0];
            integrando = integrando.Substring(1);

            // Calculando a variação de X
            double variacao = (informacoes[1] - informacoes[0]) / informacoes[2];

            // Identificando o tipo de função
            string tipofuncao = IdentificaFuncao(integrando);


            double area_trapezio;
            double integral = 0;


            if (tipofuncao == "CONSTANTE")
            {
                // Calcula a integral quando a parte é uma função constante

                double constante = StringParaDecimal(integrando);

                if (operador == '-')
                    constante *= -1;

                area_trapezio = constante * variacao * informacoes[2];
                integral = area_trapezio;

                for (double x = informacoes[0]; x <= informacoes[1] - variacao; x += variacao)
                {
                    AdicionarPonto(x, constante);
                    if (x == informacoes[1] - variacao)
                        AdicionarPonto(x + variacao, constante);
                }
            }

            else if (tipofuncao == "SENO")
            {
                // Calcula a integral quando a parte é uma função seno

                for (double x = informacoes[0]; x <= informacoes[1] - variacao; x += variacao)
                {
                    double x1 = x;
                    double x2 = x + variacao;

                    double fx1 = FuncaoTrigonometrica(integrando, x1);
                    double fx2 = FuncaoTrigonometrica(integrando, x2);

                    if (operador == '-')
                    { 
                        fx1 *= -1;
                        fx2 *= -1;
                    }

                    area_trapezio = ((fx1 + fx2) / 2) * variacao;
                    integral += area_trapezio;

                    AdicionarPonto(x1, fx1);
                    if (x2 == informacoes[1])
                        AdicionarPonto(x2, fx2);
                }
            }

            else if (tipofuncao == "COSSENO")
            {
                // Calcula a integral quando a parte é uma função cosseno

                for (double x = informacoes[0]; x <= informacoes[1] - variacao; x += variacao)
                {
                    double x1 = x;
                    double x2 = x + variacao;

                    double fx1 = FuncaoTrigonometrica(integrando, x1);
                    double fx2 = FuncaoTrigonometrica(integrando, x2);

                    if (operador == '-')
                    {
                        fx1 *= -1;
                        fx2 *= -1;
                    }

                    area_trapezio = ((fx1 + fx2) / 2) * variacao;
                    integral += area_trapezio;

                    AdicionarPonto(x1, fx1);
                    if (x2 == informacoes[1])
                        AdicionarPonto(x2, fx2);
                }
            }

            else if (tipofuncao == "EXPONENCIAL")
            {
                // Calcula a integral quando a parte é uma função exponencial

                for (double x = informacoes[0]; x <= informacoes[1] - variacao; x += variacao)
                {
                    double x1 = x;
                    double x2 = x + variacao;

                    double fx1 = FuncaoExponencial(integrando, x1);
                    double fx2 = FuncaoExponencial(integrando, x2);

                    if (operador == '-')
                    {
                        fx1 *= -1;
                        fx2 *= -1;
                    }

                    area_trapezio = ((fx1 + fx2) / 2) * variacao;
                    integral += area_trapezio;

                    AdicionarPonto(x1, fx1);
                    if (x2 == informacoes[1])
                        AdicionarPonto(x2, fx2);
                }
            }

            else
            {
                // Calcula a integral quando a parte é uma função polinomial
                for (double x = informacoes[0]; x <= informacoes[1] - variacao; x += variacao)
                {
                    double x1 = x;
                    double x2 = x + variacao;

                    double fx1 = FuncaoPolinomial(integrando, x1);
                    double fx2 = FuncaoPolinomial(integrando, x2);

                    if (operador == '-')
                    {
                        fx1 *= -1;
                        fx2 *= -1;
                    }

                    area_trapezio = ((fx1 + fx2) / 2) * variacao;
                    integral += area_trapezio;

                    AdicionarPonto(x1, fx1);
                    if (x2 == informacoes[1])
                        AdicionarPonto(x2, fx2);
                }
            }

            return integral;
        }

        double FuncaoPolinomial(string funcao, double variavel)
        {
            /* Realiza o cálculo de uma função do tipo k*x^n */

            int indexMult = funcao.IndexOf('*');
            int indexExp = funcao.IndexOf('^');

            double coeficiente = 1;
            double expoente = 1;

            if (indexMult != -1)
                coeficiente = StringParaDecimal(funcao.Substring(0, indexMult));

            if (indexExp != -1)
                expoente = StringParaDecimal(funcao.Substring(indexExp + 1));

            return coeficiente * Math.Pow(variavel, expoente);
        }

        public double FuncaoTrigonometrica(string funcao, double variavel)
        {
            /* Realiza o cálculo de uma função do tipo seno ou cosseno */
            int index_sen = funcao.IndexOf("sen");
            int index_cos = funcao.IndexOf("cos");

            double coeficiente = 1;
            string angulo_str = "";
            double angulo = 0;

            // SENO
            if (index_sen != -1)
            {
                if (index_sen != 0)
                {
                    string f = funcao.Substring(0, index_sen);
                    f = f.Replace("x", variavel.ToString()).Replace("*", "");
                    coeficiente = StringParaDecimal(f);
                }

                angulo_str = funcao.Substring(index_sen + 4).Replace(")", "");
            }
            // COSSENO
            else
            {
                if (index_cos != 0)
                {
                    string f = funcao.Substring(0, index_cos);
                    f = f.Replace("x", variavel.ToString()).Replace("*","");
                    coeficiente = StringParaDecimal(f);
                }

                angulo_str = funcao.Substring(index_cos + 4).Replace(")", "");
            }


            // Calculando o ângulo
            string[] angulo_pt = QuebraFuncao(angulo_str);
            int ind = 0;
            do
            {
                char operador = angulo_pt[ind][0];
                string integrando = angulo_pt[ind].Substring(1);

                double angulo_parte = CalcularFuncao(integrando, variavel);

                if (operador == '+')
                {
                    angulo += angulo_parte;
                }
                else
                {
                    angulo -= angulo_parte;
                }

                ind++;
            } while (ind < angulo_pt.Length);


            if (index_sen != -1)
            {
                return coeficiente * Math.Sin(angulo);
            }
            else
            {
                return coeficiente * Math.Cos(angulo);
            }
        }


        double FuncaoExponencial(string funcao, double variavel)
        {
            /* Realiza o cálculo de uma função do tipo e^x*/

            int index_e = funcao.IndexOf('e');

            double coeficiente_e = 1;

            if (index_e != 0)
                coeficiente_e = StringParaDecimal(funcao.Substring(0, index_e));

            string expoente_str = funcao.Substring(index_e + 2).Replace("(", "").Replace(")", "");
            double expoente = 0;
            string[] expoente_pt = QuebraFuncao(expoente_str);

            int ind = 0;
            do
            {
                char operador = expoente_pt[ind][0];
                string integrando = expoente_pt[ind].Substring(1);

                double angulo_parte = CalcularFuncao(integrando, variavel);

                if (operador == '+')
                    expoente += angulo_parte;
                else
                    expoente -= angulo_parte;

                ind++;
            } while (ind < expoente_pt.Length);


            return coeficiente_e * Math.Pow(Math.E, expoente);
        }

        double CalcularFuncao(string funcao, double variavel)
        {
            /* String para calcular o valor de y para uma função e um valor de x dado.
             * 
             * Ex: CalcularFuncao("x^2",2) retorna 4
             *     CalcularFuncao("sen(x)",0) retorna 0
             */

            string tipofuncao = IdentificaFuncao(funcao);

            if (tipofuncao == "CONSTANTE")
            {
                // Calcula y quando a parte é uma função constante
                return StringParaDecimal(funcao);
            }

            else if (tipofuncao == "SENO")
            {
                // Calcula y quando a parte é uma função seno
                return FuncaoTrigonometrica(funcao, variavel);
            }

            else if (tipofuncao == "COSSENO")
            {
                // Calcula y quando a parte é uma função cosseno
                return FuncaoTrigonometrica(funcao, variavel);
            }

            else if (tipofuncao == "EXPONENCIAL")
            {
                // Calcula y quando a parte é uma função exxponencial
                return FuncaoExponencial(funcao, variavel);
            }

            else
            {
                // Calcula y quando a parte é uma função polinomial
                return FuncaoPolinomial(funcao, variavel);
            }
        }

        public double StringParaDecimal(string fracao)
        {
            double numero;
            
            // Remove parênteses
            fracao = fracao.Replace("(", "").Replace(")", "");
            
            // Verificar se é uma fração
            int indexBarra = fracao.IndexOf('/');

            if (indexBarra != -1)
            {
                double numerador = double.Parse(fracao.Substring(0, indexBarra));     // O que estiver antes da barra é numerador
                double denominador = double.Parse(fracao.Substring(indexBarra + 1));  // O que estiver após a barra é denominador
                numero = numerador / denominador;
            }
            else
                numero = double.Parse(fracao);

            return numero;
        }
    }
}

