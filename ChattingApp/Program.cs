using System;
using System.Windows.Forms;

namespace ChattingApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 한 PC에서 테스트용: 예 = 철수, 아니오 = 영희
            var result = MessageBox.Show(
                "이 클라이언트를 '철수'로 실행할까요?\n\n예 = 철수\n아니오 = 영희",
                "사용자 선택",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            string userName = (result == DialogResult.Yes) ? "철수" : "영희";

            Application.Run(new Form1(userName));
        }
    }
}
