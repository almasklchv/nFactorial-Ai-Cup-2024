import { Header } from '@/components/header';
import { Wrapper } from '@/components/wrapper';
import Title from './components/Title';
import { useState } from 'react';
import { Button } from '@/components/ui/button';
import { useDropzone } from 'react-dropzone';
import axios from 'axios';
import { saveAs } from 'file-saver';
import styles from './generate.module.css';

interface FileWithProgress {
  file: File;
  progress: number;
}

const Generate = () => {
  const [images, setImages] = useState<FileWithProgress[]>([]);
  const [uploadProgress, setUploadProgress] = useState<Record<string, number>>({});
  const [isUploading, setIsUploading] = useState(false);

  const onDrop = (acceptedFiles: File[]) => {
    const newFiles = acceptedFiles.map((file) => ({ file, progress: 0 }));
    setImages([...images, ...newFiles]);
  };

  const { getRootProps, getInputProps, isDragActive } = useDropzone({
    accept: {
      'image/*': []
    },
    onDrop,
    multiple: true,
  });

  const handleRemove = (fileToRemove: File, event: React.MouseEvent) => {
    event.stopPropagation();
    setImages(images.filter(({ file }) => file !== fileToRemove));
    setUploadProgress((prevProgress) => {
      // eslint-disable-next-line @typescript-eslint/no-unused-vars
      const { [fileToRemove.name]: _, ...rest } = prevProgress;
      return rest;
    });
  };

  const handleSubmit = async () => {
    setIsUploading(true);
    const formData = new FormData();
    images.forEach(({ file }) => {
      formData.append('images', file);
    });

    try {
      const response = await axios.post(
        'https://excelai-latest.onrender.com/api/OpenAIAPI/tableFromImages',
        formData,
        {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
          responseType: 'blob',
          onUploadProgress: (progressEvent) => {
            const { loaded, total } = progressEvent;
            if (total) {
              const percentage = Math.floor((loaded * 100) / total);
              setUploadProgress((prevProgress) => {
                const updatedProgress = { ...prevProgress };
                images.forEach(({ file }) => {
                  updatedProgress[file.name] = percentage;
                });
                return updatedProgress;
              });
            }
          },
        }
      );

      const blob = new Blob([response.data], {
        type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
      });
      saveAs(blob, 'table.xlsx');
    } catch (error) {
      console.error('Error uploading images:', error);
    } finally {
      setIsUploading(false);
      setUploadProgress({});
    }
  };

  return (
    <Wrapper>
      <Header linksColor="#000" />
      <Title />
      <div className={styles.container}>
        <div
          {...getRootProps()}
          className={`${styles.dropzone} ${isDragActive ? styles.active : ''}`}
        >
          <input {...getInputProps()} />
          {isDragActive ? (
            <p>Drop the files here ...</p>
          ) : (
            <div>
              <p>Drag &apos;n&apos; drop some files here, or click to select files</p>
              <Button style={{ marginTop: '10px' }}>Upload</Button>
            </div>
          )}
          <div className={styles['file-list']}>
            {images.map(({ file }, index) => (
              <div key={index} className={styles['file-item']}>
                <span>{file.name}</span>
                {!isUploading && (
                  <Button onClick={(event) => handleRemove(file, event)}>Remove</Button>
                )}
                {uploadProgress[file.name] !== undefined && (
                  <div className={styles['progress-bar']}>
                    <div
                      className={styles.progress}
                      style={{ width: `${uploadProgress[file.name]}%` }}
                    ></div>
                  </div>
                )}
              </div>
            ))}
          </div>
        </div>
      </div>
      <div className="flex justify-center mt-12">
        <Button
          style={{
            maxWidth: '200px',
            fontSize: '20px',
            height: '50px',
            padding: '0px 150px',
          }}
          onClick={handleSubmit}
        >
          Give me the table
        </Button>
      </div>
    </Wrapper>
  );
};

export default Generate;
