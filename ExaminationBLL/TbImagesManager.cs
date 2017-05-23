using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationModels;
using ExaminationDAL;
using System.Data;

namespace ExaminationBLL
{
    public class TbImagesManager
    {
        static TbImageService imageService = new TbImageService();

        /// <summary>
        /// 添加试卷图片
        /// </summary>
        /// <param name="image"></param>
        public static void AddImage(TbImages image)
        {
            imageService.AddImage(image);
        }

        /// <summary>
        /// 根据试卷ID获取对应所有图片
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public static DataTable GetImagesBySjid(int sjid)
        {
            return imageService.GetImagesBySjid(sjid);
        }

        /// <summary>
        /// 根据试卷ID删除对应所有图片
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public static int DeleteImageBySjid(int sjid)
        {
            return imageService.DeleteImageBySjid(sjid);
        }
    }
}
