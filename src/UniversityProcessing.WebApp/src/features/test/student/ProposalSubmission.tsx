import type React from 'react';
import { useState } from 'react';
import { Button, CircularProgress, Paper, TextField, Typography } from '@mui/material';

const ProposalSubmission: React.FC = () => {
  const [title, setTitle] = useState('');
  const [abstract, setAbstract] = useState('');
  const [file, setFile] = useState<File | null>(null);
  const [isSubmitting, setIsSubmitting] = useState(false);

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files) {
      setFile(event.target.files[0]);
    }
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setIsSubmitting(true);

    // Here you would typically send the proposal to your backend
    // This is a mock API call
    await new Promise((resolve) => setTimeout(resolve, 2000));

    console.log('Submitted:', { title, abstract, file });
    setIsSubmitting(false);
    // Reset form or show success message
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4">
      <Typography variant="h6" gutterBottom>
        Submit Proposal
      </Typography>
      <Paper className="p-4 space-y-4">
        <TextField fullWidth label="Proposal Title" value={title} onChange={(e) => setTitle(e.target.value)} required />
        <TextField
          fullWidth
          label="Abstract"
          multiline
          rows={4}
          value={abstract}
          onChange={(e) => setAbstract(e.target.value)}
          required
        />
        <input
          accept=".pdf,.doc,.docx"
          style={{ display: 'none' }}
          id="proposal-file"
          type="file"
          onChange={handleFileChange}
        />
        <label htmlFor="proposal-file">
          <Button variant="outlined" component="span">
            Upload Proposal Document
          </Button>
        </label>
        {file && <Typography>{file.name}</Typography>}
        <Button
          type="submit"
          variant="contained"
          color="primary"
          disabled={isSubmitting}
          startIcon={isSubmitting ? <CircularProgress size={20} /> : null}
        >
          Submit Proposal
        </Button>
      </Paper>
    </form>
  );
};

export default ProposalSubmission;

