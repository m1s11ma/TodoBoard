select C.ClientName, count(CC.Id) as ContactsCount 
from public.Clients as C
left join public.ClientContacts as CC
on C.Id = CC.Clientid
group by C.Clientname