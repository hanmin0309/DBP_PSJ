using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        // 직원 데이터 모델
        public class Employee
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public bool IsVisibleToUser { get; set; }
        }

        private List<Employee> employees = new List<Employee>();

        private string loginUserId;

        public Form1(string userId)
        {
            InitializeComponent();
            loginUserId = userId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 만약 lblUser 같은 라벨 있으면
            // lblUser.Text = $"로그인: {loginUserId}";

            // 기존 코드 그대로 유지

            // 직원 예시 데이터
            employees.Add(new Employee { ID = "E001", Name = "홍길동", Department = "인사", IsVisibleToUser = true });
            employees.Add(new Employee { ID = "E002", Name = "김철수", Department = "개발", IsVisibleToUser = true });
            employees.Add(new Employee { ID = "E003", Name = "이영희", Department = "디자인", IsVisibleToUser = false });
            employees.Add(new Employee { ID = "E004", Name = "박상민", Department = "개발", IsVisibleToUser = true });
            employees.Add(new Employee { ID = "E005", Name = "최수진", Department = "인사", IsVisibleToUser = true });

            LoadEmployeesToTreeView(employees);
        }

        // 직원 데이터를 트리뷰에 표시
        private void LoadEmployeesToTreeView(List<Employee> list)
        {
            tvEmployees.Nodes.Clear();

            var groups = list.GroupBy(x => x.Department);

            foreach (var dept in groups)
            {
                TreeNode deptNode = new TreeNode(dept.Key);

                foreach (var emp in dept)
                {
                    if (emp.IsVisibleToUser)
                        deptNode.Nodes.Add(new TreeNode($"{emp.Name} ({emp.ID})"));
                }

                tvEmployees.Nodes.Add(deptNode);
            }

            tvEmployees.ExpandAll();
        }

        // 검색 버튼 클릭
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadEmployeesToTreeView(employees);
                return;
            }

            var filtered = employees
                .Where(emp => emp.Name.Contains(keyword) || emp.ID.Contains(keyword))
                .ToList();

            LoadEmployeesToTreeView(filtered);
        }

        // 즐겨찾기 추가 버튼
        private void btnAddFav_Click(object sender, EventArgs e)
        {
            if (tvEmployees.SelectedNode == null)
                return;

            string selectedName = tvEmployees.SelectedNode.Text;

            if (!lstFavorites.Items.Contains(selectedName))
                lstFavorites.Items.Add(selectedName);
        }

        // 즐겨찾기 제거 버튼
        private void btnRemoveFav_Click(object sender, EventArgs e)
        {
            if (lstFavorites.SelectedItem == null)
                return;

            lstFavorites.Items.Remove(lstFavorites.SelectedItem);
        }
    }
}
