type NameFields = {
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
};


const fullName = (person?: NameFields | null): string => {
  if (!person) return '';
  const { firstName, lastName, middleName } = person;
  return `${lastName} ${firstName}${middleName ? ' ' + middleName : ''}`;
};

export const namingTools = { fullName };
