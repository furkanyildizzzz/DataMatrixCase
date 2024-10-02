using DataMatrix.net;
using DataMatrixCase.Application.Interfaces.Repositories;
using DataMatrixCase.Infrastructure.Interfaces.Services;
using KeepDynamic.BarcodeReader;
using System.Drawing;
using DataMatrixCase.Domain.Entities;
using DataMatrixCase.Application.Dto;

namespace DataMatrixCase.Infrastructure
{
    public class DataMatrixService : IDataMatrixService
    {
        private readonly IDataMatrixInfoRepository _dataMatrixInfoRepository;
        public DataMatrixService(IDataMatrixInfoRepository dataMatrixInfoRepository)
        {
            _dataMatrixInfoRepository = dataMatrixInfoRepository;
        }

        public async Task<List<DataMatrixInfoDto>> DecodedItems()
        {
            List<DataMatrixInfo> dataMatrixInfos = await _dataMatrixInfoRepository.GetAsync();

            List<DataMatrixInfoDto> decodedItemsDto = dataMatrixInfos.Select(s => new DataMatrixInfoDto
            {
                CreatedAt = s.CreatedAt,
                DecodedData = s.DecodedData,
                FileName = s.FilePath
            }).ToList();

            return decodedItemsDto;
        }

        public async Task<List<string>> Decode(MemoryStream stream, string fileName)
        {
            List<string> decodedCodes = new List<string>();
            Bitmap bitmap = new Bitmap(stream);

            string[] barcodeValues = BarcodeReader.read(bitmap, KeepDynamic.BarcodeReader.Type.DATAMATRIX);

            if (barcodeValues != null && barcodeValues.Length > 0) decodedCodes = barcodeValues[0].Split(" ").ToList();
            else
            {
                DmtxImageDecoder decoder = new DmtxImageDecoder();
                decodedCodes = decoder.DecodeImage(bitmap, 100, new TimeSpan(0, 0, 10));
            }

            if (decodedCodes != null && decodedCodes.Count > 0)
            {
                // Generate a unique ID using Guid
                //string uniqueId = Guid.NewGuid().ToString();

                //// Add the unique ID to the beginning of the file name
                //string newFileName = uniqueId + "_" + fileName;

                //string filePath = SaveFileLocally(stream, newFileName);

                DataMatrixInfo entity = await _dataMatrixInfoRepository.AddAsync(new DataMatrixInfo
                {
                    CreatedAt = DateTime.Now,
                    DecodedData = string.Join("|", decodedCodes),
                    FilePath = fileName
                });

            }

            return decodedCodes;
        }


        private async Task<string> SaveFileLocally(Stream imageStream, string fileName)
        {
            // Define the path where you will save the file
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            string filePath = Path.Combine(uploadsFolder, fileName);

            // Ensure the directory exists
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Save the file to the disk
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageStream.CopyToAsync(fileStream);
            }
            return filePath;
        }

        public async Task ClearAll()
        {
            await _dataMatrixInfoRepository.ClearAllAsync();
        }
    }
}
