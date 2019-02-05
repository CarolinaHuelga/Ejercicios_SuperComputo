using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Diana Carolina Huelga Huerta
/// 04/02/019 
/// Tarea 1 - Supercómputo
/// </summary>
namespace CargaArchivos_Hilos
{
    public partial class Hilos : Form
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        Thread hiloPalabras, hiloLetras;
        string contenido = "";
        int tamanio = 0;
        bool pausaLetras = false, pausaPalabras = false, iniciaLetras = false, iniciaPalabras = false;

        /// <summary>
        /// Constructor de la clase Hilos
        /// </summary>
        public Hilos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se presiona la opcion para
        /// agregar un nuevo archivo
        /// </summary>
        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "|*.txt";
                openFileDialog.Title = "Selecciona un archivo de texto";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var file = openFileDialog.OpenFile();

                    lblArchivo.Text = Path.GetFileName(openFileDialog.FileName);
                    tamanio = (int)file.Length;

                    using (StreamReader reader = new StreamReader(file))
                    {
                        contenido = reader.ReadToEnd();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el archivo: " + ex.Message);
            }
        }

        #region Eventos para iniciar
        /// <summary>
        /// Evento que se ejecuta cuando se presiona el botón de iniciar de las palabras
        /// </summary>
        private void btnIniciarPalabras_Click(object sender, EventArgs e)
        {
            if (contenido.Length > 0)
            {
                if (!pausaPalabras)
                {
                    iniciaPalabras = true;
                    hiloPalabras = new Thread(new ThreadStart(leePalabras));
                    hiloPalabras.Start();
                }
                else
                {
                    pausaPalabras = false;
                }
                if (InvokeRequired)
                    Invoke(new Action(() => lblPalabras.Text = "CORRIENDO"));
            }
            else
            {
                MessageBox.Show("No se ha elegido un archivo, o éste esta vacío");
            }
        }
        /// <summary>
        /// Evento que se ejecuta cuando se presiona el botón de iniciar de las letras
        /// </summary>
        private void btnIniciarLetras_Click(object sender, EventArgs e)
        {
            if (contenido.Length > 0)
            {
                if (!pausaLetras)
                {
                    iniciaLetras = true;
                    hiloLetras = new Thread(new ThreadStart(leeLetras));
                    hiloLetras.Start();
                }
                else
                {
                    pausaLetras = false;
                }
                if (InvokeRequired)
                    Invoke(new Action(() => lblLetras.Text = "CORRIENDO"));
            }
            else
            {
                MessageBox.Show("No se ha elegido un archivo, o éste esta vacío");
            }

        }

        #endregion

        #region Eventos para pausar

        /// <summary>
        /// Evento que se ejecuta cuando se presiona la opcion de pausar de las palabras
        /// </summary>
        private void btnPausarPalabras_Click(object sender, EventArgs e)
        {
            if (!iniciaPalabras)
            {
                pausaPalabras = true;
                if (InvokeRequired)
                    Invoke(new Action(() => lblPalabras.Text = "PAUSADO"));
            }
            else
            {
                MessageBox.Show("No se ha iniciado la lectura del archivo");
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se presiona la opcion de pausar de las letras
        /// </summary>
        private void btnPausarLetras_Click(object sender, EventArgs e)
        {
            if (iniciaLetras)
            {
                pausaLetras = true;
                if (InvokeRequired)
                    Invoke(new Action(() => lblLetras.Text = "PAUSADO"));
            }
            else
            {
                MessageBox.Show("No se ha iniciado la lectura del archivo");
            }

        }

        #endregion

        #region Eventos para detener

        /// <summary>
        /// Evento que se ejecuta cuando se presiona la opcion de detener de las palabras
        /// </summary>
        private void btnDetenerPalabras_Click(object sender, EventArgs e)
        {
            if (!iniciaPalabras)
            {
                if (hiloPalabras != null)
                    hiloPalabras.Abort();
                pausaPalabras = false;
                if (InvokeRequired)
                    Invoke(new Action(() => txtPalabras.Text = ""));
                if (InvokeRequired)
                    Invoke(new Action(() => lblPalabras.Text = "DETENIDO"));
            }else
            {
                MessageBox.Show("No se ha iniciado la lectura del archivo");
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se presiona la opcion de detener de las letras
        /// </summary>
        private void btnDetenerLetras_Click(object sender, EventArgs e)
        {
            if (!iniciaLetras)
            {
                if (InvokeRequired)
                    Invoke(new Action(() => A.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => B.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => C.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => D.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => E.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => F.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => G.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => H.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => I.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => J.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => K.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => L.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => M.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => N.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => Ñ.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => O.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => P.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => Q.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => R.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => S.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => T.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => U.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => V.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => W.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => X.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => Y.Text = "0"));
                if (InvokeRequired)
                    Invoke(new Action(() => Z.Text = "0"));

                if (hiloLetras != null)
                {
                    hiloLetras.Abort();
                }
                pausaLetras = false;
                if (InvokeRequired)
                    Invoke(new Action(() => lblLetras.Text = "DETENIDO"));
            }
            else
            {
                MessageBox.Show("No se ha iniciado la lectura del archivo");
            }
        }

        #endregion

        #region Métodos de lectura

        /// <summary>
        /// Método del hilo para hacer la evaluacion de letras en el archivo
        /// </summary>
        private void leeLetras()
        {
            try
            {
                for (int i = 0; i < tamanio; i++)
                {
                    switch (contenido[i].ToString().ToUpper())
                    {
                        case "A":
                            if (InvokeRequired)
                                Invoke(new Action(() => A.Text = (int.Parse(A.Text) + 1).ToString()));
                            break;
                        case "B":
                            if (InvokeRequired)
                                Invoke(new Action(() => B.Text = (int.Parse(B.Text) + 1).ToString()));
                            break;
                        case "C":
                            if (InvokeRequired)
                                Invoke(new Action(() => C.Text = (int.Parse(C.Text) + 1).ToString()));
                            break;
                        case "D":
                            if (InvokeRequired)
                                Invoke(new Action(() => D.Text = (int.Parse(D.Text) + 1).ToString()));
                            break;
                        case "E":
                            if (InvokeRequired)
                                Invoke(new Action(() => E.Text = (int.Parse(E.Text) + 1).ToString()));
                            break;
                        case "F":
                            if (InvokeRequired)
                                Invoke(new Action(() => F.Text = (int.Parse(F.Text) + 1).ToString()));
                            break;
                        case "G":
                            if (InvokeRequired)
                                Invoke(new Action(() => G.Text = (int.Parse(G.Text) + 1).ToString()));
                            break;
                        case "H":
                            if (InvokeRequired)
                                Invoke(new Action(() => H.Text = (int.Parse(H.Text) + 1).ToString()));
                            break;
                        case "I":
                            if (InvokeRequired)
                                Invoke(new Action(() => I.Text = (int.Parse(I.Text) + 1).ToString()));
                            break;
                        case "J":
                            if (InvokeRequired)
                                Invoke(new Action(() => J.Text = (int.Parse(J.Text) + 1).ToString()));
                            break;
                        case "K":
                            if (InvokeRequired)
                                Invoke(new Action(() => K.Text = (int.Parse(K.Text) + 1).ToString()));
                            break;
                        case "L":
                            if (InvokeRequired)
                                Invoke(new Action(() => L.Text = (int.Parse(L.Text) + 1).ToString()));
                            break;
                        case "M":
                            if (InvokeRequired)
                                Invoke(new Action(() => M.Text = (int.Parse(M.Text) + 1).ToString()));
                            break;
                        case "N":
                            if (InvokeRequired)
                                Invoke(new Action(() => N.Text = (int.Parse(N.Text) + 1).ToString()));
                            break;
                        case "Ñ":
                            if (InvokeRequired)
                                Invoke(new Action(() => Ñ.Text = (int.Parse(Ñ.Text) + 1).ToString()));
                            break;
                        case "O":
                            if (InvokeRequired)
                                Invoke(new Action(() => O.Text = (int.Parse(O.Text) + 1).ToString()));
                            break;
                        case "P":
                            if (InvokeRequired)
                                Invoke(new Action(() => P.Text = (int.Parse(P.Text) + 1).ToString()));
                            break;
                        case "Q":
                            if (InvokeRequired)
                                Invoke(new Action(() => Q.Text = (int.Parse(Q.Text) + 1).ToString()));
                            break;
                        case "R":
                            if (InvokeRequired)
                                Invoke(new Action(() => R.Text = (int.Parse(R.Text) + 1).ToString()));
                            break;
                        case "S":
                            if (InvokeRequired)
                                Invoke(new Action(() => S.Text = (int.Parse(S.Text) + 1).ToString()));
                            break;
                        case "T":
                            if (InvokeRequired)
                                Invoke(new Action(() => T.Text = (int.Parse(T.Text) + 1).ToString()));
                            break;
                        case "U":
                            if (InvokeRequired)
                                Invoke(new Action(() => U.Text = (int.Parse(U.Text) + 1).ToString()));
                            break;
                        case "V":
                            if (InvokeRequired)
                                Invoke(new Action(() => V.Text = (int.Parse(V.Text) + 1).ToString()));
                            break;
                        case "W":
                            if (InvokeRequired)
                                Invoke(new Action(() => W.Text = (int.Parse(W.Text) + 1).ToString()));
                            break;
                        case "X":
                            if (InvokeRequired)
                                Invoke(new Action(() => X.Text = (int.Parse(X.Text) + 1).ToString()));
                            break;
                        case "Y":
                            if (InvokeRequired)
                                Invoke(new Action(() => Y.Text = (int.Parse(Y.Text) + 1).ToString()));
                            break;
                        case "Z":
                            if (InvokeRequired)
                                Invoke(new Action(() => Z.Text = (int.Parse(Z.Text) + 1).ToString()));
                            break;
                    }
                    while (pausaLetras) { }
                }
                if (InvokeRequired)
                    Invoke(new Action(() => lblLetras.Text = "TERMINADO"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }

        }

        /// <summary>
        /// Método del hilo para hacer la evaluacion de palabras en el archivo
        /// </summary>
        private void leePalabras()
        {
            try
            {
                string[] todas = contenido.Split(' ');
                List<PalabraEncontrada> palabras = new List<PalabraEncontrada>();

                for (int i = 0; i < todas.Length; i++)
                {
                    if (palabras.Find(p => p.Palabra == todas[i]) == null)
                    {
                        palabras.Add(new PalabraEncontrada(todas[i], 1));
                    }
                    else
                    {
                        var x = palabras.FindIndex(p => p.Palabra == todas[i]);
                        palabras[x].Numero = palabras[x].Numero + 1;
                    }
                    if (InvokeRequired)
                        Invoke(new Action(() => txtPalabras.Text = ""));

                    for (int j = 0; j < palabras.Count; j++)
                    {
                        if (InvokeRequired)
                            Invoke(new Action(() => txtPalabras.Text += (palabras[j].Palabra + " = " + palabras[j].Numero + "\r\n")));
                        while (pausaPalabras) { }
                    }

                    while (pausaPalabras) { }
                }

                if (InvokeRequired)
                    Invoke(new Action(() => lblPalabras.Text = "TERMINADO"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        } 

        #endregion
    }
    /// <summary>
    /// Clase para almacenar las palabras encontradas en el archivo
    /// </summary>
    public class PalabraEncontrada
    {
        public string Palabra { get; set; }
        public int Numero { get; set; }

        public PalabraEncontrada(string palabra, int num)
        {
            Palabra = palabra;
            Numero = num;
        }
    }
}
