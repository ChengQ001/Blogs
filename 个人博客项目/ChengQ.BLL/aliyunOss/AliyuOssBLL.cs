using Aliyun.OSS;
using Aliyun.OSS.Common;
using ChengQ.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChengQ.BLL
{
    public class AliyuOssBLL
    {
        private readonly OssClient client = null;
        private readonly string endpoint = "";
        private readonly string accessKeySecret = "";
        private readonly string accessKeyId = "";
        private readonly string bucketName = "";
        public AliyuOssBLL()
        {
            endpoint = "oss-cn-beijing.aliyuncs.com";
            accessKeyId = "LTAI4rZAiIzFNrMW";
            accessKeySecret = "Zf5J2Akds15dbBpdTvAXYyBSzTBfih";
            bucketName = "chengqingpublice";
            client = new OssClient(endpoint, accessKeyId, accessKeySecret);
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        public async Task<UploadImgEntity> FileUpload(Stream ReadStream, string contentType, string FileName)
        {
            if (ReadStream == null)
                return new UploadImgEntity();
            if (string.IsNullOrEmpty(contentType))
                return new UploadImgEntity();
            if (string.IsNullOrEmpty(FileName))
                return new UploadImgEntity();
            string fileType = System.IO.Path.GetExtension(FileName);
            string key = Guid.NewGuid().ToString("N") + fileType;
            try
            {
                client.SetBucketAcl(bucketName, CannedAccessControlList.PublicReadWrite);
                ObjectMetadata objectMeta = new ObjectMetadata();
                //设置内容长度
                objectMeta.ContentLength = ReadStream.Length;
                //设置内容类型
                objectMeta.ContentType = contentType;
                client.PutBigObject(bucketName, key, ReadStream, objectMeta);
            }
            catch (OssException)
            {
                //ResponseCode.RspException, ex.ErrorCode + "---" + ex.Message + "---" + ex.RequestId + "---" + ex.HostId, ResponseMsg.RspFailed
                return new UploadImgEntity();
            }
            UploadImgEntity uploadImgEntity = new UploadImgEntity();
            uploadImgEntity.code = 0;
            uploadImgEntity.msg = "成功";
            uploadImgEntity.data = new DataInfo() { src = "https://" + bucketName + "." + endpoint + "/" + key, title = "图片" };
            return uploadImgEntity;
        }

        public async Task<Hashtable> FileUploadKindEditor(Stream ReadStream, string contentType, string FileName)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = "上传错误";
            if (ReadStream == null)
                return hash;
            if (string.IsNullOrEmpty(contentType))
                return hash;
            if (string.IsNullOrEmpty(FileName))
                return hash;
            string fileType = System.IO.Path.GetExtension(FileName);
            string key = Guid.NewGuid().ToString("N") + fileType;
            try
            {
                client.SetBucketAcl(bucketName, CannedAccessControlList.PublicReadWrite);
                ObjectMetadata objectMeta = new ObjectMetadata();
                //设置内容长度
                objectMeta.ContentLength = ReadStream.Length;
                //设置内容类型
                objectMeta.ContentType = contentType;
                client.PutBigObject(bucketName, key, ReadStream, objectMeta);
            }
            catch (OssException)
            {
                //ResponseCode.RspException, ex.ErrorCode + "---" + ex.Message + "---" + ex.RequestId + "---" + ex.HostId, ResponseMsg.RspFailed
                return hash;
            }
            hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = "https://" + bucketName + "." + endpoint + "/" + key;
            return hash;
        }
    }
}
