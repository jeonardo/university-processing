import type React from 'react';
import { useState } from 'react';
import { Button, FormControl, InputLabel, MenuItem, Paper, Select, TextField, Typography } from '@mui/material';

const SupervisorTopicSelection: React.FC = () => {
  const [supervisor, setSupervisor] = useState('');
  const [topic, setTopic] = useState('');
  const [customTopic, setCustomTopic] = useState('');

  // This data would typically come from an API
  const supervisors = [
    { id: 1, name: 'Dr. John Doe' },
    { id: 2, name: 'Prof. Jane Smith' },
    { id: 3, name: 'Dr. Michael Johnson' }
  ];

  const topics = [
    { id: 1, title: 'Machine Learning in Healthcare' },
    { id: 2, title: 'Blockchain for Supply Chain Management' },
    { id: 3, title: 'Sustainable Energy Solutions' },
    { id: 4, title: 'Custom Topic' }
  ];

  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    // Here you would typically send the selection to your backend
    console.log('Submitted:', { supervisor, topic: topic === 'Custom Topic' ? customTopic : topic });
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4">
      <Typography variant="h6" gutterBottom>
        Select Supervisor and Topic
      </Typography>
      <Paper className="p-4 space-y-4">
        <FormControl fullWidth>
          <InputLabel id="supervisor-label">Supervisor</InputLabel>
          <Select
            labelId="supervisor-label"
            value={supervisor}
            onChange={(e) => setSupervisor(e.target.value)}
            required
          >
            {supervisors.map((s) => (
              <MenuItem key={s.id} value={s.id}>
                {s.name}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <FormControl fullWidth>
          <InputLabel id="topic-label">Topic</InputLabel>
          <Select labelId="topic-label" value={topic} onChange={(e) => setTopic(e.target.value)} required>
            {topics.map((t) => (
              <MenuItem key={t.id} value={t.title}>
                {t.title}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        {topic === 'Custom Topic' && (
          <TextField
            fullWidth
            label="Custom Topic"
            value={customTopic}
            onChange={(e) => setCustomTopic(e.target.value)}
            required
          />
        )}
        <Button type="submit" variant="contained" color="primary">
          Submit Selection
        </Button>
      </Paper>
    </form>
  );
};

export default SupervisorTopicSelection;

