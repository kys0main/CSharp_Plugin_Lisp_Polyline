using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.LinkLabel;
using System.Threading;

namespace ClassLibrary1
{
    public partial class MainForm : Form
    {
        private List<ObjectId> uniqueObjectIDs;
        public MainForm()
        {
            InitializeComponent();
            uniqueObjectIDs = new List<ObjectId>();
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            //проверяем являются ли поля ввода пустыми или состоящими из пробелов
            if (string.IsNullOrWhiteSpace(dxfield.Text) || string.IsNullOrWhiteSpace(dyfield.Text))
            {
                MessageBox.Show("Введите dX и dY");
                return;
            }
            double dx = 0;
            double dy = 0;
            //пытаемся преобразовать значения полей в тип double и передать в переменные dx и dy
            //если не удается, то сообщаем об ошибке
            if (!double.TryParse(dxfield.Text, out dx) || !double.TryParse(dyfield.Text, out dy))
            {
                MessageBox.Show("Неверное значение dX или dY. Введите числа");
                return;
            }
            //создаем список типа Line для сохранения всех линий с чертежа
            List<Line> lines = new List<Line>();
            //получение текущего документа 
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            //получение базы данных текущего документа
            Database db = doc.Database;
            //создание транзакции для работы с базой данных
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                //получение таблицы блоков из текущей БД
                BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                //получение записи пространства модели из таблицы блоков
                BlockTableRecord modelSpace = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;
                //в цикле проходим по каждому объекту из пространства модели 
                foreach (ObjectId objId in modelSpace)
                {
                    //проверяем является ли текущий объект линией
                    if (objId.ObjectClass.DxfName.Equals("LINE"))
                    {
                        //если да, то получаем объект Line из БД
                        Line line = tr.GetObject(objId, OpenMode.ForRead) as Line;
                        //и добавляем его в список
                        lines.Add(line);
                    }
                }
                //подверждаем транзакцию
                tr.Commit();
            }
            //создаем список, который будет содержать идентификаторы линий подходящих под условие
            List<ObjectId> matchedObjectIDs = new List<ObjectId>();
            bool previousLineMatched = false;
            //в цикле перебираем линии из чертежа для проверки на соответствие dx и dy
            for (int i = 0; i < lines.Count - 1; i++)
            {
                //получаем текущую линию
                Line currentLine = lines[i];
                //получаем последующую линию
                Line nextLine = lines[i + 1];
                //вычисляем расстояние между конечной точкой текующей линии и начальной точкой следующей линии
                double distance = currentLine.EndPoint.DistanceTo(nextLine.StartPoint);
                //проверка, удовлетворяет ли расстояние между линиями dx и dy
                bool currentLineMatched = distance <= dx && distance <= dy;
                //если текущая или предыдущая линия удовлетворяет условию, то добавляем идентификатор текущей линии в список
                if (currentLineMatched || previousLineMatched)
                {
                    matchedObjectIDs.Add(currentLine.ObjectId);
                }
                //если текущая линия удовлетворяет условию, то добавляем идентификатор следующей линии в список 
                if (currentLineMatched)
                {
                    matchedObjectIDs.Add(nextLine.ObjectId);
                }
                //присваиваем значение переменной, которая содержит значение, соответствует текущая линия условию или нет
                //переменной, которая будет содержать значение, соответствует ли условию предыдущая линия
                previousLineMatched = currentLineMatched;
            }
            //сначала очищаем список, который содержит идентификаторы соответствующих линий
            uniqueObjectIDs.Clear();
            //добавляем в список уникальные идентификаторы списка matchedObjectIDs
            uniqueObjectIDs = matchedObjectIDs.Distinct().ToList();
            //очищаем строки в таблице
            MainTable.Rows.Clear();
            int k = 0;
            //в цикле проходимся по каждой линии
            foreach (ObjectId objectId in uniqueObjectIDs)
            {
                //создание транзакции для работы с БД
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    //получаем объект Line из БД по его идентификатору
                    Line line = tr.GetObject(objectId, OpenMode.ForRead) as Line;
                    //добавляем в таблицу строку, которая содержит порядковый номер линии и начальные и конечные координаты линии
                    MainTable.Rows.Add(k+1, line.StartPoint.X, line.StartPoint.Y, line.EndPoint.X, line.EndPoint.Y);
                    //подтверждаем транзакцию
                    tr.Commit();
                }
                k++;
            }
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            List<int> blockCount=new List<int>();
            //List<ObjectId> newIds=new List<ObjectId>();
            double dx = 0;
            double dy = 0;
            double.TryParse(dxfield.Text, out dx);
            double.TryParse(dyfield.Text, out dy);
            blockCount.Add(0);
            //получение текущего документа
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            //получение базы данных текущего документа
            Database db = doc.Database;
            using(Transaction tr=db.TransactionManager.StartTransaction())
            {
                for (int i = 0; i < uniqueObjectIDs.Count - 1; i++)
                {
                    Line line1 = tr.GetObject(uniqueObjectIDs[i], OpenMode.ForRead) as Line;
                    Line line2 = tr.GetObject(uniqueObjectIDs[i + 1], OpenMode.ForRead) as Line;
                    double distance = line1.EndPoint.DistanceTo(line2.StartPoint);
                    if (distance > dx && distance > dy)
                    {
                        blockCount.Add(i+1);
                    }
                }
                blockCount.Add(uniqueObjectIDs.Count);
                tr.Commit();
            }
            //создание блокировки документа для предотвращения изменений другими ресурсами
            using (DocumentLock docLock = doc.LockDocument()) 
            {
                //создание транзакции для работы с БД
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    //получение таблицы блоков из БД 
                    BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
                    //получение записи пространства модели из таблицы блоков
                    BlockTableRecord modelSpace = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    for(int i = 0; i < blockCount.Count-1; i++)
                    {
                        //создание полилинии 
                        Polyline polyline = new Polyline();
                        //в цикле проходим по идентификаторам каждой из линии для создания всех вершин полилинии
                        
                        for (int start = blockCount[i]; start < blockCount[i+1];start++)
                        {
                            if (start >= uniqueObjectIDs.Count)
                            {
                                continue;
                            }
                            //получаем объект типа Line из БД с возможностью записи
                            Line line = tr.GetObject(uniqueObjectIDs[start], OpenMode.ForWrite) as Line;
                            //добавляем вершину полилинии по координатам начальной точки линии
                            polyline.AddVertexAt(polyline.NumberOfVertices, new Point2d(line.StartPoint.X, line.StartPoint.Y), 0.0, 0.0, 0.0);
                            //добавляем вершину полилинии по координатам конечной точки полилинии
                            polyline.AddVertexAt(polyline.NumberOfVertices, new Point2d(line.EndPoint.X, line.EndPoint.Y), 0.0, 0.0, 0.0);
                            //удаляем текущую линию из пространства модели
                            line.Erase();
                        }
                        //добавляем полилинию в запись пространства модели
                        modelSpace.AppendEntity(polyline);
                        //добавляем новый объект полилинии в транзакцию
                        tr.AddNewlyCreatedDBObject(polyline, true);
                    }
                    //подтверждаем транзакцию
                    tr.Commit();
                }
            }
            //закрываем форму после выполнения
            this.Close();
        }
    }
}