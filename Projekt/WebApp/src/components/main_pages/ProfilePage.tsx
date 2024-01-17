import { getUser, setUser } from "../../User";
import { GetUser, GetMaxPostsForUser, GetPostsForUser, PutUser } from "../../Client";
import { useEffect, useState } from "react";
import Paginator from "../Paginator";

import PostList from "./PostList";
import UserProfile from "./UserProfile";
import { getPhrase } from "../LanguageSelector";

function ProfilePage() {
    const [posts, setPosts] = useState([]);
    const [maxPages, setMaxPages] = useState(1);
    const [page, setPage] = useState(1);

    const [editing, setEditing] = useState(false);
    const [bio, setBio] = useState('');

    const [locj, setLocj] = useState(JSON.parse(getUser() ? getUser() as string : "{'userName': 'err', 'bio': 'err', 'id': 0}"));

    console.log(locj);
    
    useEffect(() => {

        GetPostsForUser(locj.id, page)
        .then((res) => {
            setPosts(res);
            console.log(res);
        }).catch((err) => {
            console.error(err);
            setPosts([]);
        });

        GetMaxPostsForUser(locj.id)
        .then((res) => { 
            setMaxPages(res);
        }).catch((err) => {
            console.error(err);
            setMaxPages(1);
        });
    }, [page, locj]);

    const buttonHanlde = () => {
        if (editing){
            var newlocj = JSON.parse(JSON.stringify(locj));
            newlocj.bio = bio;
            PutUser(newlocj).then((res) => {
                console.log(res);
                setLocj(newlocj);
                setUser(newlocj);
                setBio(locj.bio);
            }).catch((err) => {
                console.error(err);
            });
        } 
        setEditing(!editing);
    }

    var bioedit = (
            <div className='bio-edit'> 
                <input className='bio-input' 
                    style={{'display' : editing ? 'block' : 'none'}} 
                    value={bio} 
                    onChange={(e) => setBio(e.target.value)}></input>
                <button className='btn btn-primary' onClick={buttonHanlde}>
                    {editing ? getPhrase('save-bio') : getPhrase('edit-bio')}
                </button>
            </div> );

    return (<>
        <div className="profile">
            <UserProfile user={locj} />
            {bioedit}
            <Paginator maxPages={maxPages} currentPage={page} setCurrentPage={setPage}/>
            <PostList posts={posts} navigateToUser={() => 1} />            
        </div>
    </>);
}

export default ProfilePage;