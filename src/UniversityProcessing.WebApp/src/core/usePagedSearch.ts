import { useEffect, useState } from 'react';

interface UsePagedSearchParams<TArgs> {
  getData: (args: TArgs) => any;
  pageSize: number;
}

export function usePagedSearch<TArgs extends { filter?: string; pageNumber: number; pageSize: number }>(params: UsePagedSearchParams<TArgs>) {
  const { getData, pageSize } = params;
  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');

  useEffect(() => {
    const handle = setTimeout(() => {
      getData({ filter: search, pageNumber, pageSize } as TArgs);
    }, 300);
    return () => clearTimeout(handle);
  }, [getData, search, pageNumber, pageSize]);

  const onSearchValueChanged = (value: string) => {
    setPageNumber(1);
    setSearch(value ?? '');
  };

  return { pageNumber, setPageNumber, onSearchValueChanged, search } as const;
}


