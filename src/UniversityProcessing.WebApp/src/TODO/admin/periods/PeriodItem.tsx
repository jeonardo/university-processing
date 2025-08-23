const PeriodsPage: React.FC = ({ item }) => {
  return (
    <ListItem key={item.id} className="py-4 flex justify-between items-center">
      <ListItemText
        primary={item.shortName}
        secondary={
          <Typography variant="body2" color="text.secondary" component="span">
            {item.name}
          </Typography>
        }
      />
    </ListItem>);
};

export default PeriodsPage;