%Sa se genereze lista aranjamentelor de K elemente, cu elementele unei liste date.


domains
elem=integer
list=elem*
listd=list*

predicates

ar(list,integer,list)
ar_all(list,integer,listd)
ins(elem,list,list)


clauses
%if N=1 then an arrangement is [E]
ar([E|_],1,[E]).

%generate arrangements with N elements
ar([_|L],N,X):-ar(L,N,X).

%insert elem A on all positions in the arrangements having N-1 elements
ar([A|L],N,X):-
N<>1,
N1=N-1,
ar(L,N1,Y),
ins(A,Y,X).

%insert elem E on all positions of the given list (2nd parameter)
ins(E,L,[E|L]).
ins(E,[A|L],[A|X]):-ins(E,L,X).

ar_all(L,N,R):-findall(X,ar(L,N,X),R).